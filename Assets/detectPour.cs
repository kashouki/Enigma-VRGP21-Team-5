using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPour : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pot;
    public bubble b;
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Pour: " + Vector3.Dot(transform.forward, new Vector3(0, -1, 0)));
        Debug.Log(Mathf.Pow(pot.position.x - transform.position.x, 2) + Mathf.Pow(pot.position.z - transform.position.z, 2));
        if (Vector3.Dot(transform.forward, new Vector3(0, -1, 0)) > 0.3f && Mathf.Pow(pot.position.x - transform.position.x, 2) + Mathf.Pow(pot.position.z - transform.position.z, 2) < 0.2f)
        {
            Debug.Log("above pot & pour");
            GetComponent<ParticleSystem>().Play();
            b.bubbling = true;
        }
        else
        {
            GetComponent<ParticleSystem>().Stop();
        }
        /*
        if (Vector3.Dot(transform.forward, new Vector3(0, -1, 0)) > 0.3f)
        {
            Debug.Log("POUR");
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            GetComponent<ParticleSystem>().Stop();
        }
        */
    }
}
