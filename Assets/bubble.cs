using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    public bool bubbling;
    // Start is called before the first frame update
    void Start()
    {
        bubbling = false;
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbling)
        {
            GetComponent<ParticleSystem>().Play();
            Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBubbling");
        }
        else
            GetComponent<ParticleSystem>().Stop();
    }
}
