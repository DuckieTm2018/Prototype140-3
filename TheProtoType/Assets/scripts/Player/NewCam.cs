using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewCam : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    public float miniumVert = -45f;
    public float maximumVert = 45f;

    public float sensHorizontal = 10f;
    public float sensVertical = 10f;

    public float _rotationX = 0;

    void Update()
    {
        if (axes ==RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        } else if (axes == RotationAxis.MouseY) { 
       
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            _rotationX = Mathf.Clamp(_rotationX, miniumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
} 