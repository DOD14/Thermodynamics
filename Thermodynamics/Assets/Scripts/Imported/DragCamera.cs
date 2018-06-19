using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour
{

    public Camera myCamera;
    public float panSpeed = 2;
    private Vector3 dragOrigin;

    private float moveSmooth = 0.1f;


    public float x, y, width, height;


    ////////
    // Awake
    void Awake()
    {
        // DontDestroyOnLoad( this ); if( FindObjectsOfType( GetType() ).Length > 1 ) Destroy( gameObject );
        ResetCamera();
    }

    ////////
    // Start
    void Start()
    {
        ResetCamera();
    }

    ////////////////
    // RESET: Camera
    public void ResetCamera()
    {
        if (myCamera == null) myCamera = Camera.main;
        //// Camera Origin
        x = 0; y = 0;
        height = 2f * myCamera.orthographicSize;
        width = height * myCamera.aspect;
        myCamera.rect = new Rect(x, y, width, height);
    }

    /////////
    // Update
    void Update()
    {
        //// Moving of camera via click / drag
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            dragOrigin = myCamera.ScreenToWorldPoint(dragOrigin);

        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (!Physics.Raycast(ray, 20f))
                {
                    Vector3 currentPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                    currentPos = myCamera.ScreenToWorldPoint(currentPos);
                    Vector3 movePos = dragOrigin - currentPos;
                    transform.position += (movePos * moveSmooth);
            }
        }
    }

}