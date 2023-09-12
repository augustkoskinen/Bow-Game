using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shootbow : MonoBehaviour
{
    public KeyCode click = KeyCode.Mouse0;
    public KeyCode drawarrow = KeyCode.Mouse1;
    public GameObject arrow;
    public Transform campos;
    public Transform arrowpos;
    public Transform player;
    private GameObject dupearrow;
    private LayerMask RaycastLayers;
    private float holdbow = 0f;
    private Vector3 vel;
    void Update()
    {
        if (dupearrow == null&&Input.GetKey(drawarrow))
        {
            dupearrow = Instantiate(arrow, arrowpos.position, transform.rotation);
            var ran = Random.Range(0,2);
            dupearrow.GetComponent<arrowlife>().type = "basic";
            if (ran == 0)
            {
                dupearrow.GetComponent<arrowlife>().type = "pan";
            }
            dupearrow.GetComponent<arrowlife>().type = "bomb";
            dupearrow.GetComponent<Rigidbody>().useGravity = false;
        }
        if (dupearrow != null)
        {
            if (Input.GetKey(click) && holdbow < 60)
            {
                holdbow += .15f;
            }
            else if (!Input.GetKey(click)&&!Input.GetKey(KeyCode.G))
            {
                if (holdbow > .5f)
                {
                    if (!Physics.Linecast(player.position, arrowpos.position, LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Rig", "ground"))) {
                        vel = Physics.RaycastAll(campos.position, campos.forward, 60)[0].point - transform.position;
                        dupearrow.GetComponent<Rigidbody>().velocity = reduceVector(vel) *holdbow;
                        dupearrow.GetComponent<Rigidbody>().useGravity = true;
                        dupearrow = null;
                        holdbow = 0;
                    }
                    else
                    {
                        holdbow = 0;
                    }
                }
            }
        }
    }
    private Vector3 reduceVector(Vector3 vector)
    {
        float highestvalue = Mathf.Abs(vector.x);
        if (Mathf.Abs(vector.y) > highestvalue)
        {
            highestvalue = Mathf.Abs(vector.y);
        }
        if (Mathf.Abs(vector.z) > highestvalue)
        {
            highestvalue = Mathf.Abs(vector.z);
        }
        Vector3 newvector = new Vector3(vector.x/ highestvalue, vector.y / highestvalue, vector.z / highestvalue);
        return newvector;
    }
    
}
