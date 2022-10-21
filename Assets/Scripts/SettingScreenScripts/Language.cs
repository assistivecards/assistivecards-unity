using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public string LanguageName{ get; set; }
    public bool IsSelected{ get; set; }
    public string LocalName{ get; set; }

    public Language(string languageName, bool isSelected, string localName)
    {
        LanguageName = languageName;
        IsSelected = isSelected;
        LocalName = localName;
    }
}
