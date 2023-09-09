using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class arrowlife : MonoBehaviour
{
    private Rigidbody rb;
    bool startarrow = false;
    private Transform bow = null;
    public void Start()
    {
        bow = GameObject.Find("arrowpos").transform;
        rb = GetComponent<Rigidbody>();
        if (transform.position.y >30)
        {
            startarrow = true;
        }
    }
    public void Update()
    {
        if (rb != null)
        {
            if (rb.useGravity)
            {
                if (rb.velocity != Vector3.zero)
                    rb.rotation = Quaternion.LookRotation(rb.velocity);
            }
            else
            {
                transform.SetPositionAndRotation(bow.position, bow.rotation);
            }
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (rb != null)
        {
            if (rb.useGravity)
            {
                if (!startarrow && GetComponent<Rigidbody>() != null)
                {
                    rb.velocity = new(0, 0, 0);
                    rb.useGravity = false;
                    Destroy(rb);
                    Destroy(gameObject, 20);
                }
                else if (startarrow)
                {
                    rb.velocity = new(0, 0, 0);
                }
            }
        }
    }
}
