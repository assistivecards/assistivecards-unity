using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCircle : MonoBehaviour
{ 
    public bool move;
    public float moveValue, rotationRadius;
    public float speed;
    private float posX, posY;

    private void Update() 
    {
        moveValue += Time.deltaTime * speed;
        posX =  Mathf.Cos(moveValue) * rotationRadius;
        posY =  Mathf.Sin(moveValue) * rotationRadius;
        this.transform.localPosition = new Vector3( posX + 40f, posY - 15f, 0);
    }
}
