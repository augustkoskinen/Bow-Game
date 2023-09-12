using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionkill : MonoBehaviour
{
    private ParticleSystem _ps;

    public void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    public void FixedUpdate()
    {
        if (transform.position.y<60)
        {
            if (_ps && !_ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
