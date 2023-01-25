using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DrawManager : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] TMP_Text circleText;
    [SerializeField] TopAppBarController topAppBarController;
    [SerializeField] CanvasController canvasController;
    [SerializeField] private Line linePrefab;
    public Line currentLine;
    public const float RESOLUTION = 0.1f;
    [SerializeField] List<Vector2> lineRendererPoints = new List<Vector2>();
    [SerializeField] GameObject currentLineChildPrefab;
    private GameObject currentLineChild;
    private Touch touch;
    public float distanceThreshold;
    public bool isValid;


    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
                currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity);

            if (touch.phase == TouchPhase.Moved)
                currentLine.SetPosition(mousePos);

            if (touch.phase == TouchPhase.Ended)
            {
                if (lineRendererPoints.Count > 0)
                    lineRendererPoints.Clear();
                for (int i = 0; i < currentLine.GetComponent<LineRenderer>().positionCount; i++)
                    lineRendererPoints.Add(currentLine.GetComponent<LineRenderer>().GetPosition(i));

                currentLineChild = Instantiate(currentLineChildPrefab, currentLine.transform.position, Quaternion.identity);
                currentLineChild.transform.SetParent(currentLine.transform);
                currentLineChild.GetComponent<PolygonCollider2D>().points = lineRendererPoints.ToArray();
                currentLineChild.transform.position = currentLineChild.transform.InverseTransformPoint(currentLineChild.transform.position);

                if (currentLine.GetComponent<LineRenderer>().positionCount <= 5)
                    currentLineChild.GetComponent<DetectCollision>().FadeOutAndDestroyLine();

                if (currentLine.GetComponent<LineRenderer>().positionCount >= 2)
                {
                    if (Vector2.Distance(currentLine.GetComponent<LineRenderer>().GetPosition(0), currentLine.GetComponent<LineRenderer>().GetPosition(currentLine.GetComponent<LineRenderer>().positionCount - 1)) < distanceThreshold)
                        isValid = true;
                    else
                        isValid = false;
                }

                Debug.Log("isValid: " + isValid);

                Invoke("CheckIfLineCollidesWithAnything", 0.05f);

            }
        }

    }

    private void CheckIfLineCollidesWithAnything()
    {
        if (currentLineChild.GetComponent<DetectCollision>().collisionCount == 0)
        {
            currentLineChild.GetComponent<DetectCollision>().FadeOutAndDestroyLine();
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

    public void ClearLineClone()
    {
        if (currentLine != null)
            Destroy(currentLine.gameObject);
    }
}
