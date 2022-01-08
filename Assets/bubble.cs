using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    //public bool bubbling;
    public int type;
    public cauidron c;
    public GameObject Firewood;
    private FirewoodBurn Firewood_script;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        //bubbling = false;
        GetComponent<ParticleSystem>().Stop();

        Firewood_script = Firewood.GetComponent<FirewoodBurn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (c.status == type)
        {
            if (Firewood_script.isOnFireAndBlown &&  flag)
            {
                flag = false;
                GetComponent<ParticleSystem>().Play();
                Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBubbling");
            }
        }
        else
        {
            flag = true;
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
