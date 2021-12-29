using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject playerCurrentPos;

    public GameObject initPos;
    public GameObject gatePos;

    public GameObject probe;

    public GameObject doorTrigger;
    public GameObject crowTrigger;
    public GameObject dwarfTrigger;

    public List<GameObject> palaceBoundary;
    public List<GameObject> crowBoundary;
    public List<GameObject> dwarfBoundary;

    private bool isPalace = true;
    private bool isForest = false;

    /*0 = before; 1 = during; 2 = after*/
    private int kingState = 0;
    private int crowState = 0;
    private int dwarfState = 0;




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
            if (kingState == 0)
            {
                palaceBoundary[0].SetActive(true);
                kingState = 1;
            }
            else if (kingState == 1)
            {
                palaceBoundary[0].SetActive(false);
                kingState = 2;
            }
            else if (kingState == 2)
            {
                palaceBoundary[0].SetActive(false);
                if (Vector3.Distance(player, doorTrigger.transform.position) < 2f)
                {
                    playerCurrentPos.transform.position = gatePos.transform.position;
                    isPalace = false;
                    isForest = true;
                }
            }
        }
        else if (isForest)
        {
            if (crowState == 0)
            {
                crowBoundary[0].SetActive(true);
                crowBoundary[1].SetActive(false);
                if (Vector3.Distance(player, crowTrigger.transform.position) < 6f)
                {
                    crowState = 1;
                }
            }
            else if (crowState == 1)
            {
                crowBoundary[0].SetActive(true);
                crowBoundary[1].SetActive(true);
            }
            else if (crowState == 2)
            {
                crowBoundary[0].SetActive(false);
                crowBoundary[1].SetActive(false);
            }

            if (dwarfState == 0)
            {
                dwarfBoundary[0].SetActive(true);
                dwarfBoundary[1].SetActive(false);
                if (Vector3.Distance(player, crowTrigger.transform.position) < 134f)
                {
                    dwarfState = 1;
                }
            }
            else if (dwarfState == 1)
            {
                dwarfBoundary[0].SetActive(true);
                dwarfBoundary[1].SetActive(true);
            }
            else if (dwarfState == 2)
            {
                dwarfBoundary[0].SetActive(false);
                dwarfBoundary[1].SetActive(false);
            }
        }
    }
}
