using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headcollision : MonoBehaviour
{
    public bool colliding = false;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = new(0, 0, 0);
    }
    // Update is called once per frame
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        colliding = true;
        print("here");
    }
    void OnCollisionExit(UnityEngine.Collision collision)
    {
        colliding = false;
    }
}
