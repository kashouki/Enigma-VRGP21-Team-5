using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject playerCurrentPos;

    public GameObject initPos;
    public GameObject gatePos;

    public GameObject doorTrigger;
    public GameObject crowTrigger;
    public GameObject dwarfTrigger;

    public List<GameObject> palaceBoundary;
    public List<GameObject> crowBoundary;
    public List<GameObject> DawrfBoundary;

    private int gameState = 0;

    private bool isPalace = true;
    private bool isForest = false;



    // Start is called before the first frame update
    void Start()
    {
        playerPos.transform.position = initPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = playerCurrentPos.transform.position;
        if (isPalace)
        {
            if (player.x >= doorTrigger.transform.position.x)
            {
                playerCurrentPos.transform.position = gatePos.transform.position;
            }
        }
        else if (isForest)
        {

        }
    }
}
