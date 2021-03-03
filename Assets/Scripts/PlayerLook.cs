using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private enum LookAxis{Empty, MouseX, MouseY};
    [SerializeField] LookAxis chosenAxis = LookAxis.Empty;
    [SerializeField] private float sensitivity = 10f;

    
    Quaternion quaternionX;
    Quaternion quaternionY;

    private float rotationX;
    private float rotationY;

    private Quaternion startQuaternion;

    void Start()
    {
        startQuaternion = transform.localRotation;
    }

    void Update()
    {
        if (chosenAxis == LookAxis.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            quaternionX = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = startQuaternion * quaternionX;
        }

        if (chosenAxis == LookAxis.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, -50, 50);
            quaternionY = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = startQuaternion * quaternionY;
        }
    }
}
