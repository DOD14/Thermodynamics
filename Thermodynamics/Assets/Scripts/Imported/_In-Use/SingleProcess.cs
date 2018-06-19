using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SingleProcess : MonoBehaviour {

    public InputField pInput1;
    public InputField vInput1;
    public InputField pInput2;
    public InputField vInput2;
    public InputField indexInput;

    public int resolution = 5;
    public int myNumber = 0;

    private float p1;
    private float p2;
    private float v1;
    private float v2;
    private float index = 1;

    private LineRenderer lineRenderer;
    private Drawer drawerScript;

    private UnityAction valueChangedListener;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        valueChangedListener = new UnityAction(DrawProcess);
        drawerScript = GetComponentInParent<Drawer>();
            
        DrawProcess();
    }

    private void OnEnable()
    {
        EventManager.StartListening("valueChanged" + myNumber.ToString(), valueChangedListener);
        Debug.Log("listening for " + myNumber.ToString());

    }

    private void OnDisable()
    {
        EventManager.StopListening("valueChanged" + myNumber.ToString(), valueChangedListener);

    }

    // Update is called once per frame
    public void DrawProcess () 
    {
        Debug.Log("drawProcess");

        GrabAllValues();

        if (!indexInput.IsActive())
            DrawSimple();
        else {
            GrabIndex();
            Debug.Log("index is " + index);
            DrawPolytropicByVolume(); 
        }
	}

    void DrawSimple()
    {
        Debug.Log("DrawSimple");

        p1 *= drawerScript.pFactor;
        p2 *= drawerScript.pFactor;
        v1 *= drawerScript.vFactor;
        v2 *= drawerScript.vFactor;

        Vector3 startPos = new Vector3(v1, p1, 0f);
        Vector3 endPos = new Vector3(v2, p2, 0f);

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    void DrawPolytropicByVolume()
    {
        Debug.Log("PolytropicByVolume");

        Vector3[] positions = new Vector3[resolution + 1];
        float increment = (v2 - v1) / resolution;
        for (int i = 0; i <= resolution; i++)
        {
            float v = v1 + i * increment;
            float p = p1 * Mathf.Pow(v1 / v, index);

            p *= drawerScript.pFactor;
            v *= drawerScript.vFactor;

            positions[i] = new Vector3(v, p, 0f);
        }

        lineRenderer.positionCount = resolution + 1;
        lineRenderer.SetPositions(positions);
    }

    void GrabAllValues()
    {
        Debug.Log("GrabAllValues");

        p1 = float.Parse(pInput1.text);
        p2 = float.Parse(pInput2.text);
        v1 = float.Parse(vInput1.text);
        v2 = float.Parse(vInput2.text);
    }

    void GrabIndex()
    {
        Debug.Log("GrabIndex");
        index = float.Parse(indexInput.text);
    }

}
