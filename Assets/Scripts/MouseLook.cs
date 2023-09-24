using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseLook : MonoBehaviour
{
    public float xsense = 1000;
    public float ysense = 1000;

    float xrot;
    float yrot;

    private Vector3 position = new(0, 0, 0);

    public GameObject orientation;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = !UnityEngine.Cursor.visible;
        
        //orientation = GameObject.Find("Orientation");
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xsense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ysense * Time.deltaTime;

        xrot -= mouseY;
        yrot += mouseX;
        xrot = Mathf.Clamp(xrot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xrot, yrot, 0f);
        orientation.transform.rotation = Quaternion.Euler(0, yrot, 0f);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UnityEngine.Cursor.visible)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.visible = true;
            }
        }
        if (Input.GetKey(KeyCode.G))
        {
            position = transform.forward * -5;
            gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig", "ground", "Player2", "Player1", "Eyes", "head");
        }
        else
        {
            position = new(0f, 1f, 0f);
            gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig", "ground", "Player2", "head"); ;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
            position.y = .5f;
        }
        else
        {
            position.y = 1f;
        }
        transform.localPosition = position;
    }
}
