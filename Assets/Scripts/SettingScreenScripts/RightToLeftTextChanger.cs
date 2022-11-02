using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RightToLeftTextChanger : MonoBehaviour
{
    private TMP_Text[] tMP_Texts;
    public void RightToLeftLangugeChanged()
    {
        tMP_Texts = this.GetComponentsInChildren<TMP_Text> ();

        foreach(TMP_Text tMP_Text in tMP_Texts)
        {
            tMP_Text.isRightToLeftText = true;
        }
    }

    public void LeftToRightLanguageChanged()
    {
        tMP_Texts = this.GetComponentsInChildren<TMP_Text> ();

        foreach(TMP_Text tMP_Text in tMP_Texts)
        {
            tMP_Text.isRightToLeftText = false;
        }
    }
}
