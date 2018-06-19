using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderers : MonoBehaviour {

    public Transform[] markers;
    public int resolution = 5;
    public float index = 1;

    // Use this for initialization
    void Start()
    {

        int markersLength = markers.Length;

        /*for (int i = 0; i <= markersLength; i++)
        {
            LineRenderer currentRenderer = markers[i].GetComponent<LineRenderer>();
            currentRenderer.SetPosition(0, markers[i % markersLength].transform.position);
            currentRenderer.SetPosition(1, markers[(i + 1) % markersLength].transform.position);
        
            else
            {*/
                    
        float p1 = markers[0].transform.position.x;
        float v1 = markers[0].transform.position.y;
        float p2 = markers[1].position.x;

        LineRenderer currentRenderer = markers[0].GetComponent<LineRenderer>();

        SetPolytropicPositions(index, p1, p2, v1, resolution, currentRenderer);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetPolytropicPositions(float n, float p1, float p2, float v1, int resolution, LineRenderer renderer)
    {
        Vector3[] positions = new Vector3[resolution+1];
        float increment = (p2 - p1) / resolution;
        for (int i = 0; i <= resolution; i++)
        {
            float p = p1 + i * increment;
            float v = v1 * Mathf.Pow(p1 / p, 1 / n);
            positions[i] = new Vector3(p, v, 0f);
        }

        renderer.positionCount = resolution+1;
        renderer.SetPositions(positions);

    }

}
