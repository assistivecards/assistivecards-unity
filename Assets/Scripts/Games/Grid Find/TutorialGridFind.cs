using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGridFind : MonoBehaviour
{
    private List<GameObject> correctCardsList;
    private int onEnabledCount = 0;

    private void OnEnable() 
    {
        SetPosition();
        onEnabledCount++;
    }

    public void GetPositionList(List<GameObject> _correctCardsList) 
    {
        correctCardsList = _correctCardsList;
    }

    private void SetPosition()
    {
        LeanTween.move(this.gameObject, correctCardsList[onEnabledCount].transform.position, 0);
    }

    public void ClearPositionList() 
    {
        correctCardsList.Clear();
    }
}
