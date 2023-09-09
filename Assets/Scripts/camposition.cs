using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class camposition : MonoBehaviour
{
    public KeyCode camshiftkey = KeyCode.G;
    private Vector3 position = new(0f, 1f, 0f);
    public Transform player;
    public Transform orientation;
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
            position.y = .5f;
        }
        else
        {
            position.y = 1f;
        }
        /*
        if (Input.GetKey(KeyCode.G))
        {
            transform.position = transform.forward*-5;
        } else {
            transform.localPosition = new(0f, 1f, 0f);
        }
        */
        transform.localPosition = position;
    }
}
