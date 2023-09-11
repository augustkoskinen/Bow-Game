using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class arrowlife : MonoBehaviour
{
    //head types
    public MeshFilter headmesh;
    public MeshRenderer headmat;
    public BoxCollider box; 
    public Mesh panmesh;
    public Material panmat;
    private Vector3 pancolsize = new Vector3(0.7f,0.2f,0.6f);
    private Vector3 pancolplace = new Vector3(0f, -0.04f, 0.5f);


    private Rigidbody rb;
    bool startarrow = false;
    private Transform bow = null;
    public string type = "basic";
    public void Start()
    {
        headmesh.mesh = null;
        headmat.material = null;
        box.size = new(0, 0, 0);
        box.center = new(0, 0, 0);
        if (type == "pan")
        {
            headmesh.mesh = panmesh;
            headmat.material = panmat;
            box.size = pancolsize;
            box.center = pancolplace;
        }

        rb = GetComponent<Rigidbody>();
        bow = GameObject.Find("arrowpos").transform;
        if (transform.position.y >30)
        {
            startarrow = true;
        }
    }
    public void Update()
    {
        if (!startarrow)
        {
            if (rb != null)
            {
                if (!rb.useGravity)
                {
                    transform.SetPositionAndRotation(bow.position, bow.rotation);
                }
                else
                {
                    if (rb.velocity != Vector3.zero)
                        rb.rotation = Quaternion.LookRotation(rb.velocity);
                }
            }
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        stopmoving();
    }

    void stopmoving()
    {
        if (rb != null)
        {
            if (rb.useGravity)
            {
                if (!startarrow)
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
