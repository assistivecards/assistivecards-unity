using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyGenerator : MonoBehaviour
{
    [SerializeField] private BoardGenerator boardGenerator;

    public void EasyModeClick()
    {
        boardGenerator.cardNumber = 6;
    }

    public void NormalModeClick()
    {
        boardGenerator.cardNumber = 12;
    }

    public void HardModeClick()
    {
        boardGenerator.cardNumber = 18;
    }
}
