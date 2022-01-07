using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFirewoodBool : MonoBehaviour
{

    public GameObject Firewood;
    private FirewoodBurn Firewood_script;

    // Start is called before the first frame update
    void Start()
    {
        Firewood_script = Firewood.GetComponent<FirewoodBurn>();
        Debug.Log("isOnFireAndBlown: " + Firewood_script.isOnFireAndBlown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
