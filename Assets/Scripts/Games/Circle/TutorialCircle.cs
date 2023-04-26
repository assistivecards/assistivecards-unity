using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCircle : MonoBehaviour
{ 
    public float moveValue, rotationRadius;
    private float posX, posY;

    private void Update() 
    {
        moveValue += Time.deltaTime * 5f;
        posX =  Mathf.Cos(moveValue) * rotationRadius;
        posY =  Mathf.Sin(moveValue) * rotationRadius;
        transform.position = new Vector3(posX, posY, 0);
    }
}
