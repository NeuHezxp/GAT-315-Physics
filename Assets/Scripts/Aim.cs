using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float sensitivity = 3;
    Vector3 rotation = Vector3.zero;
    Vector2 prevAxis = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        prevAxis.y = Input.GetAxis("Mouse X");
        prevAxis.x = -Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.y = Input.GetAxis("Mouse X") - prevAxis.x;
        axis.x = -Input.GetAxis("Mouse Y") - prevAxis.y;


        rotation.x += axis.x * sensitivity;
        rotation.y += axis.y * sensitivity;

        rotation.x = Mathf.Clamp(rotation.x, 40, 40);
        rotation.y = Mathf.Clamp(rotation.y, -40, 40);

        Quaternion qYaw = Quaternion.AngleAxis(axis.y * sensitivity, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(axis.x * sensitivity, Vector3.right);

        transform.localRotation = (qYaw *qPitch );
    }
}
