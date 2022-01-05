using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluid : MonoBehaviour
{
    public bool pouring;
    // Start is called before the first frame update
    void Start()
    {
        pouring = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.up.z > 0.3f)
        {
            Debug.Log("POUR");
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
