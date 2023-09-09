using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour
{
    public Transform cameraposition;
    //public Transform playerposition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraposition.position;
    }
}
