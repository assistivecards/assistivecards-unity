/*
 * Author:Misaka-Mikoto
 * Date: 2021-02-08
 * Url:https://github.com/Misaka-Mikoto-Tech/ScratchImage
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// ���Թο���ͼ��
/// </summary>
public class ScratchImage : MonoBehaviour
{
    public struct StatData
    {
        public float fillPercent;  // ���ٷֱȣ���0ֵ��
        public float avgVal;       // ƽ��ֵ
    }

    /// <summary>
    /// ֱ��ͼͰ��������������shader�ж����һ��, ��С��256
    /// </summary>
    public const int HISTOGRAM_BINS = 128;
    /// <summary>
    /// ��������͸���ȵ�RT���Image�ߴ�ı�����ֵԽС����Խ�ߣ����Ǿ��Ⱥ�Ч��ҲԽ��
    /// </summary>
    public const float ALPHA_RT_SCALE = 0.4f;
    /// <summary>
    /// ÿһ���ε�ʵ���������ޣ�̫����Щ�豸�����쳣��
    /// </summary>
    public const int INSTANCE_COUNT_PER_BATCH = 200;

    public Camera uiCamera;
    /// <summary>
    /// �ɰ���ͼ
    /// </summary>
    public Image maskImage;
    /// <summary>
    /// ��ˢ��ͼ
    /// </summary>
    public Texture2D brushTex;

    /// <summary>
    /// ��ˢ�ߴ�
    /// </summary>
    [Range(1f, 200f)]
    public float brushSize = 50f;
    /// <summary>
    /// ���Ʋ�������(ֵ������ɵ�������С��������ѹ��)
    /// TODO �ĳɸ���brushSize�Զ�����
    /// </summary>
    [Range(1f, 20f)]
    public float paintStep = 5f;
    /// <summary>
    /// ��ˢ�ƶ������ֵ
    /// </summary>
    [Range(1f, 10f)]
    public float moveThreshhold = 2f;
    /// <summary>
    /// ��ˢ��͸����
    /// </summary>
    [Range(0f, 1f)]
    public float brushAlpha = 1f;
    /// <summary>
    /// ��ͼ����
    /// </summary>
    public Material paintMaterial;
    /// <summary>
    /// ��������ֱ��ͼ���ݵ�shader
    /// </summary>
    public ComputeShader histogramShader;

    /// <summary>
    /// ֱ��ͼ����
    /// </summary>
    private uint[] _histogramData;
    private ComputeBuffer _histogramBuffer;
    private int _clearShaderKrnl;
    private int _histogramShaderKrnl;
    private Vector2Int _histogramShaderGroupSize;

    private RenderTexture _rt;
    private CommandBuffer _cb;
    private bool _isDirty;
    private Vector2 _beginPos;
    private Vector2 _endPos;

    private Mesh _quad;
    private Matrix4x4 _matrixProj;
    private Matrix4x4[] _arrInstancingMatrixs;

    private int _propIDMainTex;
    private int _propIDBrushAlpha;
    private Vector2 _lastPoint;
    private Vector2 _maskSize;

    public Vector2 rtSize => new Vector2(_rt.width, _rt.height);


    /// <summary>
    /// �����ɰ�
    /// </summary>
    public void ResetMask()
    {
        SetupPaintContext(true);
        Graphics.ExecuteCommandBuffer(_cb);
        _isDirty = false;
    }

    /// <summary>
    /// ��ȡ�ο���ͳ����Ϣ
    /// </summary>
    /// <returns></returns>
    public StatData GetStatData()
    {
        if (_histogramShaderKrnl == -1)
        {
            Debug.LogError("invalid compute shader");
            return new StatData();
        }

        histogramShader.Dispatch(_clearShaderKrnl, HISTOGRAM_BINS / _histogramShaderGroupSize.x, 1, 1);

        int dispatchX = _rt.width / _histogramShaderGroupSize.x;
        int dispatchY = _rt.height / _histogramShaderGroupSize.y;
        histogramShader.Dispatch(_histogramShaderKrnl, dispatchX, dispatchY, 1);

        // AsyncGPUReadback.Request does supported at OpenglES
        _histogramBuffer.GetData(_histogramData);

        int dispatchWidth = dispatchX * _histogramShaderGroupSize.x;
        int dispatchHeight = dispatchY * _histogramShaderGroupSize.y;
        int dispatchCount = dispatchWidth * dispatchHeight;

        StatData ret = new StatData();
        ret.fillPercent = 1.0f - _histogramData[0] / (dispatchCount * 1.0f); // ��0ֵ����

        float sum = 0;
        float binScale = (256 / HISTOGRAM_BINS);
        for (int i = 0; i < HISTOGRAM_BINS; i++)
        {
            int count = (int)_histogramData[i];
            sum += i * binScale * count;
        }
        ret.avgVal = sum / dispatchCount;
        // ����Ͱ������С��256��shader���ֻͳ�Ƶ� 127 * 2 = 254, �޷���ʾ255�����ݣ���˴˴��ѽ��������һ��
        ret.avgVal *= 255.0f / ((HISTOGRAM_BINS - 1) * binScale);
        return ret;
    }

    void Start()
    {
        Init();
        ResetMask();
    }

    private void OnDestroy()
    {
        if (_rt != null)
            Destroy(_rt);

        if (_quad != null)
            Destroy(_quad);

        if (_cb != null)
            _cb.Dispose();

        if (_histogramBuffer != null)
            _histogramBuffer.Release();
    }

    private void Update()
    {
        CheckInput();
    }

    void LateUpdate()
    {
        if (BuildCommands())
        {
            Graphics.ExecuteCommandBuffer(_cb);
            _beginPos = _endPos;
        }
    }

    private bool BuildCommands()
    {
        if (!_isDirty)
            return false;

        paintMaterial.SetTexture(_propIDMainTex, brushTex != null ? brushTex : Texture2D.whiteTexture);
        paintMaterial.SetFloat(_propIDBrushAlpha, brushAlpha);

        Vector2 fromToVec = _endPos - _beginPos;
        Vector2 dir = fromToVec.normalized;
        float len = fromToVec.magnitude;

        float offset = 0;
        int instCount = 0;

        SetupPaintContext(false);

        while (offset <= len)
        {
            if (instCount >= INSTANCE_COUNT_PER_BATCH)
            {
                _cb.DrawMeshInstanced(_quad, 0, paintMaterial, 0, _arrInstancingMatrixs, instCount);
                instCount = 0;
            }

            Vector2 tmpPt = _beginPos + dir * offset;
            tmpPt -= Vector2.one * brushSize * 0.5f; // ����ˢ���е����Ƶ�
            offset += paintStep;

            _arrInstancingMatrixs[instCount++] = Matrix4x4.TRS(new Vector3(tmpPt.x, tmpPt.y, 0), Quaternion.identity, Vector3.one * brushSize);
        }

        if (instCount > 0)
        {
            _cb.DrawMeshInstanced(_quad, 0, paintMaterial, 0, _arrInstancingMatrixs, instCount);
        }

        _isDirty = false;
        return true;
    }

    private void Init()
    {
        _lastPoint = Vector2.zero;

        _quad = new Mesh();
        _quad.SetVertices(new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0)
        });

        _quad.SetUVs(0, new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(1, 0),
                new Vector2(1, 1)
            });

        _quad.SetIndices(new int[] { 0, 1, 2, 3, 2, 1 }, MeshTopology.Triangles, 0, false);
        _quad.UploadMeshData(true);


        _maskSize = maskImage.rectTransform.rect.size;
        //Debug.LogFormat("mask image size:{0}*{1}", maskSize.x, maskSize.y);

        _rt = new RenderTexture((int)(_maskSize.x * ALPHA_RT_SCALE), (int)(_maskSize.y * ALPHA_RT_SCALE), 0, RenderTextureFormat.R8, 0);
        _rt.antiAliasing = 2;
        _rt.autoGenerateMips = false;

        _arrInstancingMatrixs = new Matrix4x4[INSTANCE_COUNT_PER_BATCH];
        _matrixProj = Matrix4x4.Ortho(0, _maskSize.x, 0, _maskSize.y, -1f, 1f);

        _propIDMainTex = Shader.PropertyToID("_MainTex");
        _propIDBrushAlpha = Shader.PropertyToID("_BrushAlpha");

        paintMaterial.enableInstancing = true;

        Material maskMat = maskImage.material;
        maskMat.SetTexture("_AlphaTex", _rt);

        _cb = new CommandBuffer() { name = "PaintOncb" };

        // setup histogram compute shader
        _clearShaderKrnl = -1;
        if (histogramShader != null)
        {
            _histogramBuffer = new ComputeBuffer(HISTOGRAM_BINS, 4);
            _histogramData = new uint[HISTOGRAM_BINS];

            _clearShaderKrnl = histogramShader.FindKernel("HistogramClear");
            histogramShader.SetBuffer(_clearShaderKrnl, "_HistogramBuffer", _histogramBuffer);

            _histogramShaderKrnl = histogramShader.FindKernel("Histogram");
            histogramShader.SetTexture(_histogramShaderKrnl, "_Tex", _rt);
            histogramShader.SetBuffer(_histogramShaderKrnl, "_HistogramBuffer", _histogramBuffer);

            // setup _TexScaledSize
            {
                uint x, y, z;
                histogramShader.GetKernelThreadGroupSizes(_histogramShaderKrnl, out x, out y, out z);
                uint dispatchWidth = (uint)(_rt.width / x * x);
                uint dispatchHeight = (uint)(_rt.height / y * y);

                _histogramShaderGroupSize = new Vector2Int((int)x, (int)y);

                // Ҫ��shaderִ�еĿ���С����ʵ�������ߴ磬�Ա���uv���
                histogramShader.SetVector("_TexScaledSize", new Vector2(dispatchWidth, dispatchHeight));
            }
        }
    }

    private void SetupPaintContext(bool clearRT)
    {
        _cb.Clear();
        _cb.SetRenderTarget(_rt);

        if (clearRT)
        {
            _cb.ClearRenderTarget(true, true, Color.clear);
        }

        _cb.SetViewProjectionMatrices(Matrix4x4.identity, _matrixProj);
    }

    private void CheckInput()
    {
        if (uiCamera == null)
            return;

        int mouseStatus = 0;// 0��none, 1:down, 2:hold, 3:up

        if (Input.GetMouseButtonDown(0)) // �������
            mouseStatus = 1;
        else if (Input.GetMouseButton(0)) // �ƶ������ߴ��ڰ���״̬
            mouseStatus = 2;
        else if (Input.GetMouseButtonUp(0)) // �ͷ����
            mouseStatus = 3;

        if (mouseStatus == 0)
            return;

        Vector2 localPt = Vector2.zero;
        Vector2 mPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, mPos, uiCamera, out localPt);
        Debug.Log("Mouse position: " + Input.mousePosition);
        Debug.Log("LocalPt: " + localPt);

        //Debug.Log($"pt:{localPt}, status:{mouseStatus}");

        if (localPt.x < 0 || localPt.y < 0 || localPt.y >= _maskSize.x || localPt.y >= _maskSize.y)
            return;

        switch (mouseStatus)
        {
            case 1:
                _beginPos = localPt;
                _lastPoint = localPt;
                break;
            case 2:
                if (Vector2.Distance(localPt, _lastPoint) > moveThreshhold)
                {
                    _endPos = localPt;
                    _lastPoint = localPt;
                    _isDirty = true;
                }
                break;
            case 3:
                _endPos = localPt;
                _lastPoint = localPt;
                _isDirty = true;
                break;
        }
    }
}
