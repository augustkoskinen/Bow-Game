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
    private GameObject dupearrow;
    private float holdbow = 0f;
    void Update()
    {
        if (dupearrow == null&&Input.GetKey(drawarrow))
        {
            dupearrow = Instantiate(arrow, arrowpos.position, transform.rotation);
            dupearrow.GetComponent<Rigidbody>().useGravity = false;
        }
        if (dupearrow != null)
        {
            if (Input.GetKey(click) && holdbow < 60)
            {
                holdbow += .15f;
            }
            else if (!Input.GetKey(click))
            {
                if (holdbow > 5)
                {
                    dupearrow.GetComponent<Rigidbody>().velocity = campos.forward * holdbow;
                    dupearrow.GetComponent<Rigidbody>().useGravity = true;
                    dupearrow = null;
                    holdbow = 0;
                }
            }
        }
    }
    
}
