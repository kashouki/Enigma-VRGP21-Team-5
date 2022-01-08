using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokedGlow : MonoBehaviour
{
    public int type;
    public cauidron c;
    public detectPoke detect_poke;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (detect_poke.poked && c.status == type && flag)
        {
            flag = false;
            GetComponent<ParticleSystem>().Play();
        }
    }
}
