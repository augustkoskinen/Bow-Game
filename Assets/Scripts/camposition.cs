using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class camposition : MonoBehaviour
{
    public KeyCode camshiftkey = KeyCode.G;
    private Vector3 position = new(0f, 1f, 0f);
    public Transform player;
    public GameObject camdir;
    public Transform orientation;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            position = camdir.transform.forward*-5;
            camdir.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig", "ground", "Player2","Player1","Eyes","head");
        } else {
            position = new(0f, 1f, 0f);
            camdir.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig","ground","Player2", "head"); ;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
            position.y = .5f;
        }
        else
        {
            position.y = 1f;
        }
        transform.rotation = camdir.transform.rotation;
        transform.localPosition = position;
    }
}
