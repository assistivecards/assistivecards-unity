using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private DrawManager drawManager;
    public int collisionCount;
    private GameObject matchedCard;
    private Color32 success = new Color32(32, 202, 32, 255);
    // Start is called before the first frame update
    void Start()
    {
        drawManager = GameObject.Find("DrawManager").GetComponent<DrawManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCount++;
        matchedCard = other.gameObject;

        if (other.gameObject.tag == "CorrectCard" && collisionCount == 1 && drawManager.isValid)
        {
            Invoke("CheckIfMatchIsCorrect", 0.05f);
        }
        else
        {
            FadeOutAndDestroyLine();
        }

    }

    public void FadeOutAndDestroyLine()
    {
        LeanTween.alpha(transform.parent.GetComponent<LineRenderer>().gameObject, 0, .25f);
        Destroy(transform.parent.gameObject, 0.25f);
    }

    public void CheckIfMatchIsCorrect()
    {
        if (transform.parent.GetComponent<LineRenderer>().material.color.a == 1)
        {
            Debug.Log("Correct Match !!!");
            LeanTween.color(transform.parent.GetComponent<LineRenderer>().gameObject, success, .25f);
        }
    }
}
