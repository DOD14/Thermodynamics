using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour {

    public GameObject[] panels;
    public InputField pMaxInputField;
    public InputField vMaxInputField;
   // public Button addButton;
   // public Button removeButton;

    private int k; //number of processes = number of input panels
    private SingleProcess[] panelScripts;

    public float pFactor = 1;
    public float vFactor = 1;

    void Awake()
    {
        k = 2;
        panelScripts = new SingleProcess[panels.Length];

        for (int i = 0; i < panelScripts.Length; i++)
            panelScripts[i] = panels[i].GetComponent<SingleProcess>();
    }

	void DrawGraphs()
    {
        for (int i = 0; i < k; i++)
            panelScripts[i].DrawProcess();
            
    }

    public void AdjustMaxPressure()
    {
        pFactor = 1 / float.Parse(pMaxInputField.text);
        DrawGraphs();
    }

    public void AdjustMaxVolume()
    {
        vFactor = 1 / float.Parse(vMaxInputField.text);
        DrawGraphs();
    }

    public void AddPanel()
    {
        if (k < panels.Length)
        {
            k++;
            Debug.Log("adding panel " + k);
            panels[k - 1].SetActive(true);
            DrawGraphs();
        }
    }

    public void RemovePanel()
    {
        if (k > 1)
        {
            panels[k - 1].SetActive(false);
            k--;
            DrawGraphs();
        }
    }
    //figure out how to manage multiple panels, add and remove them. you should probably tweak k over here to represent the number of active panels
    //so add some buttons to the UI to manage k, + and -. Make sure to change myNumber on all 5 inputFields and the button and the script. Maybe start working on the transfer button (but now it seems superfluous)
    //and drawByPressure
}
