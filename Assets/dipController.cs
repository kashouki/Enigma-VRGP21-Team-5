using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dipController : MonoBehaviour
{
    public dip D;
    public cauidron c;
    public int type;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (c.status == type)
        {
            if (D.dipping)
            {
                if (flag)
                {
                    flag = false;
                    GetComponent<ParticleSystem>().Play();
                }
            }
            else
            {
                flag = true;
                GetComponent<ParticleSystem>().Stop();
            }
        }
        else
        {
            flag = true;
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
