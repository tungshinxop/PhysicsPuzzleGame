using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicChange : MonoBehaviour
{
    public Dropdown qualitySetting;
    public void SetQuality (int qualityIndex)
    {
        //QualitySettings.masterTextureLimit = qualityIndex = qualitySetting.value;
        int value = GameObject.Find("Graphic Dropdown").GetComponent<Dropdown>().value;
        QualitySettings.SetQualityLevel(value, true);
        
    }
}
