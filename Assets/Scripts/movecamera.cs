using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecamera : MonoBehaviour
{
    public GameObject cameraposition;
    //public Transform playerposition;

    private void Start()
    {
        cameraposition = GameObject.Find("PlayerCam");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraposition.transform.position;
    }
}
