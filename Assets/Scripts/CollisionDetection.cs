using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject playerCurrentPos;

    public GameObject initPos;
    public GameObject gatePos;

    public GameObject probe;

    public GameObject doorTrigger;
    public GameObject crowTrigger;
    public GameObject dwarfTrigger;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "DoorTrigger")
        {
            playerCurrentPos.transform.position = gatePos.transform.position;
        }
    }
}
