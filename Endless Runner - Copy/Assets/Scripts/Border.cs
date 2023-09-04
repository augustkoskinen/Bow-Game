using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    Spike spike;
    // Start is called before the first frame update
    void Start()
    {
        spike = FindObjectOfType<Spike>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.back * spike.speed * Time.deltaTime;



    }
}
