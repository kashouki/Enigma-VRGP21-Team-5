using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dip : MonoBehaviour
{
    public bool dipping;
    // Start is called before the first frame update
    void Start()
    {
        dipping = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Potion")
        {
            Debug.Log("DDDDDDDDDDDDDDDDDDDDDip");
            dipping = true;
        }
    }
}
