using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float speedMax;
    public float speedMin;
    public float speed;
    Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        speed = Mathf.Lerp(speedMin, speedMax, spawner.GetDifficultyPercent());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;


    }
}
