using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotation : MonoBehaviour
{

    [SerializeField] private float ROTATION_SPEED = 10.0f;
    private float pitch = 0.0f;
    private float yaw = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        OntouchMoveCamera();
    }

    void OntouchMoveCamera()
    {
        pitch += Input.GetTouch(0).deltaPosition.y * ROTATION_SPEED * Time.deltaTime;
        yaw -= Input.GetTouch(0).deltaPosition.x * ROTATION_SPEED * Time.deltaTime;
        Debug.Log(pitch +" "+ yaw);


        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
