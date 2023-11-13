using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class DetectTouchWordHunt : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerUpHandler
{
    [SerializeField] private BoardGeneratorWordHunt boardGenerator;
    public GameObject touchDetectionObject;
    public List<Color> colors = new List<Color>();
    public List<Color> usedColors = new List<Color>();
    public Color currentColor;
    public Color tempCurrentColor;
    public bool isDragging;
    private Vector2 dragStartPosition;
    private Vector2 touchPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        boardGenerator.ResetWord();
        dragStartPosition = eventData.position;
        isDragging = true;
        touchDetectionObject.SetActive(true);
        ColorPicker();
    }

    private void ColorPicker()
    {
        tempCurrentColor = colors[Random.Range(0, colors.Count)];
        if(usedColors.Count >= 10)
        {
            usedColors.Clear();
        }
        if(!usedColors.Contains(tempCurrentColor))
        {
            currentColor = tempCurrentColor;
            usedColors.Add(currentColor);
        }
        else
        {
            ColorPicker();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragEndPosition = eventData.position;
        touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        touchDetectionObject.transform.position = touchPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        touchDetectionObject.SetActive(false);
        boardGenerator.Invoke("CheckWord", 0.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touchDetectionObject.SetActive(false);
        boardGenerator.Invoke("CheckWord", 0.1f);
    }
}
