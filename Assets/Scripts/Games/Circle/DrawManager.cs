using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawManager : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] TMP_Text circleText;
    [SerializeField] TopAppBarController topAppBarController;
    [SerializeField] CanvasController canvasController;
    [SerializeField] private Line linePrefab;
    private Line currentLine;
    public const float RESOLUTION = 0.1f;
    [SerializeField] List<Vector2> lineRendererPoints = new List<Vector2>();

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
            currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);

        if (Input.GetMouseButton(0))
            currentLine.SetPosition(mousePos);

        if (Input.GetMouseButtonUp(0))
        {
            if (lineRendererPoints.Count > 0)
                lineRendererPoints.Clear();
            for (int i = 0; i < currentLine.GetComponent<LineRenderer>().positionCount; i++)
                lineRendererPoints.Add(currentLine.GetComponent<LineRenderer>().GetPosition(i));

        }
    }

    public void DisableDrawManager()
    {
        gameObject.SetActive(false);
    }

    public void EnableDrawManagerOnSettingsBackButtonClicked()
    {
        if (canvasController.currentScreen.name == "ParentLock")
        {
            if (circleText.transform.localScale == Vector3.one)
                gameObject.SetActive(true);
        }
        else if (topAppBarController.onMain)
        {
            if (circleText.transform.localScale == Vector3.one)
                gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);
    }

    public void EnableDrawManager()
    {
        if (circleText.transform.localScale == Vector3.one)
            gameObject.SetActive(true);
    }
}
