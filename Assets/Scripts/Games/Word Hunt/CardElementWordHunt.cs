using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardElementWordHunt : MonoBehaviour
{
    public string cardLetter;
    private bool oneTime;
    public int row;
    public int column;
    public int index;
    public bool filled;
}
