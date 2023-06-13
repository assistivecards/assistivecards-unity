using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FindCardFlipCard : MonoBehaviour, IPointerClickHandler
{
    private FindCardMatchDetection matchDetector;

    private void Start()
    {
        matchDetector = GameObject.Find("GamePanel").GetComponent<FindCardMatchDetection>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.rotation.eulerAngles.y < 2)
        {
            LeanTween.rotateY(gameObject, -180, .75f).setOnComplete(() => matchDetector.CheckCard(transform));
        }

    }

    public void FlipBack()
    {
        LeanTween.rotateY(gameObject, 0, .75f);
    }

}
