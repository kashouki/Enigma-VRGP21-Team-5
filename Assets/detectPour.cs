using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.up.y < -0.3f)
        {
            Debug.Log("POUR");
        }
    }
}
