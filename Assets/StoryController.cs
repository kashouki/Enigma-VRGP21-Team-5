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

    public GameObject king;
    private DialogController kingAnimation;
    private int kingDiaCount = 4;
    private float[] kingDiaDuration = { 10f, 6f, 6f, 6f };

    public GameObject dwarf;
    private DialogController dwarfAnimation;
    private int dwarfDiaCount = 2;
    private float[] dwarfDiaDuration = { 10f, 10f };

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

        playerPos.transform.position = initPos.transform.position;
        kingAnimation = king.GetComponent<DialogController>();
        dwarfAnimation = dwarf.GetComponent<DialogController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dwarfState);
        Vector3 player = playerCurrentPos.transform.position;
        Debug.Log(Vector3.Distance(player, dwarfTrigger.transform.position));

        if (isPalace)
        {
            if (kingState == 0)
            {
                palaceBoundary[0].SetActive(true);
                kingState = 1;
            }
            else if (kingState == 1)
            {
                //palaceBoundary[0].SetActive(false);
                if (kingDiaCount != 0)
                {
                    if (timer == 0)
                    {
                        kingAnimation.trigger = true;
                        timer += Time.deltaTime;
                    }
                    else if (timer < kingDiaDuration[4 - kingDiaCount])
                    {
                        timer += Time.deltaTime;
                    }
                    else if (timer > kingDiaDuration[4 - kingDiaCount])
                    {
                        timer = 0.0f;
                        kingDiaCount -= 1;
                    }
                }
                else
                {
                    kingState = 2;
                }
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
            Debug.Log("Forest");

            if (crowState == 0)
            {
                //crowBoundary[0].SetActive(true);
                crowBoundary[1].SetActive(false);
                if (Vector3.Distance(player, crowTrigger.transform.position) < 6f)
                {
                    crowState = 1;
                }
            }
            else if (crowState == 1)
            {
                //crowBoundary[0].SetActive(true);
                crowBoundary[1].SetActive(true);
            }
            else if (crowState == 2)
            {
                crowBoundary[0].SetActive(false);
                crowBoundary[1].SetActive(false);
            }

            if (dwarfState == 0)
            {
                //dwarfBoundary[0].SetActive(true);
                dwarfBoundary[1].SetActive(false);
                if (Vector3.Distance(player, dwarfTrigger.transform.position) < 2f)
                {
                    dwarfState = 1;
                }
            }
            else if (dwarfState == 1)
            {
                //dwarfBoundary[0].SetActive(true);
                dwarfBoundary[1].SetActive(true);
                if (dwarfDiaCount != 0)
                {
                    if (timer == 0)
                    {
                        dwarfAnimation.trigger = true;
                        timer += Time.deltaTime;
                    }
                    else if (timer < dwarfDiaDuration[2 - dwarfDiaCount])
                    {
                        timer += Time.deltaTime;
                    }
                    else if (timer > dwarfDiaDuration[2 - dwarfDiaCount])
                    {
                        timer = 0.0f;
                        dwarfDiaCount -= 1;
                    }
                }
                else
                {
                    dwarfState = 2;
                }
            }
            else if (dwarfState == 2)
            {
                dwarfBoundary[0].SetActive(false);
                dwarfBoundary[1].SetActive(false);
            }
        }
    }
}