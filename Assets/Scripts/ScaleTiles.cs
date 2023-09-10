using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleTiles : MonoBehaviour
{
    private readonly float tileX = 2;
    private readonly float tileY = 2;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.mainTextureScale = new Vector2(transform.localScale.x * tileX, transform.localScale.z * tileY);
    }
}

