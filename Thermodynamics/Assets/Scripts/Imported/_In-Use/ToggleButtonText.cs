using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonText : MonoBehaviour {

    private bool isDefault = true;

    private Text myText;
    private void OnEnable()
    {
        myText = GetComponentInChildren<Text>();
    }

    public void ToggleText()
    {
        isDefault = !isDefault;
        if (isDefault) myText.text = "Default";
        else myText.text = "Polytropic";
    }
}
