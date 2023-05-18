using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketFrontFollow : MonoBehaviour
{
    [SerializeField] private GameObject bucketBack;

    private void Update() 
    {
        this.transform.position = bucketBack.transform.position;
    }
}
