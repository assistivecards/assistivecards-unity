using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int collisionCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCount++;
        if (other.gameObject.tag != "CorrectCard")
        {
            FadeOutAndDestroyLine();
        }
        else if (other.gameObject.tag == "CorrectCard" && collisionCount == 1)
        {
            Invoke("CheckIfMatchIsCorrect", 0.05f);
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
        }
    }
}
