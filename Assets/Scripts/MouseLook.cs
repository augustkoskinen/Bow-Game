using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float xsense = 1000;
    public float ysense = 1000;

    float xrot;
    float yrot;

    public Transform orientation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xsense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ysense * Time.deltaTime;

        xrot -= mouseY;
        yrot += mouseX;
        xrot = Mathf.Clamp(xrot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xrot, yrot, 0f);
        orientation.rotation = Quaternion.Euler(0, yrot, 0f);
    }
}
