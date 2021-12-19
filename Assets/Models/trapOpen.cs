using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapOpen : MonoBehaviour
{
    public GameObject trapDoor;

    private void OnTriggerEnter()
    {
        trapDoor.GetComponent<Animation>().Play("trapAnimation");
    }
}
