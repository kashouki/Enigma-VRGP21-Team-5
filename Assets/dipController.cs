using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dipController : MonoBehaviour
{
    public dip D;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (D.dipping)
            GetComponent<ParticleSystem>().Play();
        else
            GetComponent<ParticleSystem>().Stop();
    }
}
