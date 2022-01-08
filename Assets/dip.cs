using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dip : MonoBehaviour
{
    public bool dipping;
    public cauidron c;

    public GameObject Firewood; //
    private FirewoodBurn Firewood_script;   //
    // Start is called before the first frame update
    void Start()
    {
        dipping = false;

        Firewood_script = Firewood.GetComponent<FirewoodBurn>();    //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (c.status == 0 || !Firewood_script.isOnFireAndBlown)
            return;
        if (other.name == "Potion")
        {
            Debug.Log("DDDDDDDDDDDDDDDDDDDDDip");
            dipping = true;
        }
    }
}
