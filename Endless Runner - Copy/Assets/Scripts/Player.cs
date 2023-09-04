using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * inputx * speed * Time.deltaTime;
        
        if(transform.position.x > maxX) {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

        }
        if(transform.position.x < minX) {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);

        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "SpikeBall") {
            gm.TakeDamage();
        }
        
    }
    
}
