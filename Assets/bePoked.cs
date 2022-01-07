using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bePoked : MonoBehaviour
{
    public detectPoke poke;
    public GameObject knife;
    public GameObject tableKnife;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (poke.poked && flag)
        {
            flag = false;
            transform.position = knife.transform.position;
            transform.rotation = knife.transform.rotation;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
