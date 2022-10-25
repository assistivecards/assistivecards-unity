using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Language : MonoBehaviour
{
    public string LanguageName{ get; set; }
    public bool IsSelected{ get; set; }
    public string LocalName{ get; set; }
    public Material appBackgroundMatrial;
    public Material inactiveRadioButtoMaterial;

    public Language(string languageName, bool isSelected, string localName)
    {
        LanguageName = languageName;
        IsSelected = isSelected;
        LocalName = localName;
    }

    private void Update() 
    {
        if(!IsSelected)
        {
            this.transform.GetChild(2).GetComponent<Image>().material = inactiveRadioButtoMaterial;
        }
    }

    public void LanguageSelected()
    {
        if(IsSelected)
        {
            this.transform.GetChild(2).GetComponent<Image>().material = appBackgroundMatrial;
        }

    }
}
