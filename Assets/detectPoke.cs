using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPoke : MonoBehaviour
{
    // Start is called before the first frame update
    public bool poked;
    void Start()
    {
        poked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "HorrorDoll")
        {
            Debug.Log("PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPoke");
            poked = true;
        }
    }
}
