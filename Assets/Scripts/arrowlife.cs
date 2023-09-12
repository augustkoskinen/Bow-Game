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
    public Transform headtrans;
    public BoxCollider box; 
    public Mesh panmesh;
    public Material panmat;
    public ParticleSystem Explosion;
    private Vector3 pancolsize = new(0.5f,0.2f,0.4f);
    private Vector3 pancolplace = new(0f, -0.04f, 0.5f);
    private Vector3 pansize = new(1,1,1);
    private Vector3 panlocation = new(0.045f, -0.14f, 0.3f);
    public Mesh bombmesh;
    public Material bombmat;
    private Vector3 bombcolsize = new(0.25f, 0.25f, 0.25f);
    private Vector3 bombcolplace = new(0f, 0,0.15f);
    private Vector3 bombsize = new(0.35f, 0.35f, 0.35f);
    private Vector3 bomblocation = new(-0.0875f, -0.157f, .135f);


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
        headtrans.localScale = new(1, 1, 1);
        headtrans.localPosition = new(0, 0, 0);
        if (type == "pan")
        {
            headmesh.mesh = panmesh;
            headmat.material = panmat;
            box.size = pancolsize;
            box.center = pancolplace;
            headtrans.localScale = pansize;
            headtrans.localPosition = panlocation;
        }
        else if(type == "bomb")
        {
            headmesh.mesh = bombmesh;
            headmat.material = bombmat;
            box.size = bombcolsize;
            box.center = bombcolplace;
            headtrans.localScale = bombsize;
            headtrans.localPosition = bomblocation;
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
                    if (type == "bomb")
                    {
                        ParticleSystem newexplostion = Instantiate(Explosion,headtrans.position,Quaternion.Euler(0,0,0));
                        Destroy(gameObject);
                    }
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
