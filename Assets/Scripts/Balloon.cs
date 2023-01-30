using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        gameObject.GetComponent<Animator>().enabled = true;
    }
}
