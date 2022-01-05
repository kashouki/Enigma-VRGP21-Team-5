using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{

    public GameObject playerPos;
    public GameObject playerCurrentPos;

    public GameObject initPos;
    public GameObject gatePos;
    public GameObject trapPos;
    public GameObject escapePos;

    public GameObject doorTrigger;
    public GameObject crowTrigger;
    public GameObject dwarfTrigger;

    public List<GameObject> palaceBoundary;
    public List<GameObject> crowBoundary;
    public List<GameObject> dwarfBoundary;

    private bool isPalace = true;
    private bool isForest = false;

    private int trapState = 0;

    /*0 = before; 1 = during; 2 = after*/
    private int kingState = 0;
    private int crowState = 0;
    private int dwarfState = 0;

    public GameObject king;
    private DialogController kingAnimation;
    private int kingDiaCount = 4;
    private float[] kingDiaDuration = { 11f, 6f, 6f, 11f };

    public GameObject crow;
    private CrowController crowAnimation;
    private int crowDiaCount = 3;
    private float[] crowDiaDuration = { 9f, 13f, 11f };

    public GameObject dwarf;
    private DialogController dwarfAnimation;
    private int dwarfDiaCount = 5;
    private float[] dwarfDiaDuration = { 8f, 7f, 6f, 5f, 6f };

    private float timer = 0.0f;

    public GameObject windTriggerArea;
    public GameObject flameTriggerArea;

    public GameObject wind;
    public GameObject flame;

    private bool hasCastWind;
    private bool hasCastFlame;

    private bool windTriggerActivated = false;
    private bool flameTriggerActivated = false;

    public GameObject trapDoor;


    // Start is called before the first frame update
    void Start()
    {

        playerPos.transform.position = initPos.transform.position;
        kingAnimation = king.GetComponent<DialogController>();
        crowAnimation = crow.GetComponent<CrowController>();
        dwarfAnimation = dwarf.GetComponent<DialogController>();

        hasCastWind = wind.GetComponent<Fire_1>().hasCastWind;
        hasCastFlame = flame.GetComponent<Fire_2>().hasCastFire;

        windTriggerArea.SetActive(false);
        flameTriggerArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = playerCurrentPos.transform.position;
        Debug.Log("wind: " + wind.GetComponent<Fire_1>().hasCastWind + " flame: " + flame.GetComponent<Fire_2>().hasCastFire);
        //Debug.Log("king: " + kingState + " crow: " + crowState + " dwarf: " + dwarfState);
        //Debug.Log("crowDist" + Vector3.Distance(player, crowTrigger.transform.position) +  "dwarfDist" + Vector3.Distance(player, dwarfTrigger.transform.position));
        

        if (isPalace)
        {
            if (kingState == 0)
            {
                palaceBoundary[0].SetActive(true);
                kingState = 1;
            }
            else if (kingState == 1)
            {
                Debug.Log("In king");
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
            if (crowState == 0)
            {
                //crowBoundary[0].SetActive(true);
                crowBoundary[1].SetActive(false);
                if (Vector3.Distance(player, crowTrigger.transform.position) < 6.5f)
                {
                    crowState = 1;
                }
            }
            else if (crowState == 1)
            {
                Debug.Log("In Crow " + trapState);
                //crowBoundary[0].SetActive(true);
                crowBoundary[1].SetActive(true);
                if (trapState == 0)
                {
                    trapDoor.GetComponent<Animation>().Play("trapAnimation");
                    Vector3 trapPoss = trapPos.transform.position;
                    playerCurrentPos.transform.position = trapPoss;
                    trapState = 1;
                }
                else if (crowDiaCount == 2 && wind.GetComponent<Fire_1>().hasCastWind == false) //wind tutorial 
                {
                    windTriggerArea.SetActive(true);
                    Debug.Log("learning wind");
                }
                else if (wind.GetComponent<Fire_1>().hasCastWind == true && trapState == 1)
                {
                    windTriggerArea.SetActive(false);
                    playerCurrentPos.transform.position = escapePos.transform.position;
                    trapState = 2;
                }
                else if (crowDiaCount != 0)
                {
                    if (timer == 0)
                    {
                        crowAnimation.trigger = true;
                        timer += Time.deltaTime;
                    }
                    else if (timer < crowDiaDuration[3 - crowDiaCount])
                    {
                        timer += Time.deltaTime;
                    }
                    else if (timer > crowDiaDuration[3 - crowDiaCount])
                    {
                        timer = 0.0f;
                        crowDiaCount -= 1;
                    }
                }
                else
                {
                    crowState = 2;
                }
            }
            else if (crowState == 2)
            {
                crowBoundary[0].SetActive(false);
                crowBoundary[1].SetActive(false);
            }

            if (dwarfState == 0 && crowState == 2)
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
                Debug.Log("In Dwarf");
                //dwarfBoundary[0].SetActive(true);
                dwarfBoundary[1].SetActive(true);
                if (flame.GetComponent<Fire_2>().hasCastFire == true)
                {
                    flameTriggerArea.SetActive(false);
                }
                if (dwarfDiaCount == 1  && flame.GetComponent<Fire_2>().hasCastFire == false) //flame tutorial
                {
                    flameTriggerArea.SetActive(true);
                    Debug.Log("learning flame");
                }
                else if (dwarfDiaCount != 0)
                {
                    if (timer == 0)
                    {
                        dwarfAnimation.trigger = true;
                        timer += Time.deltaTime;
                    }
                    else if (timer < dwarfDiaDuration[5 - dwarfDiaCount])
                    {
                        timer += Time.deltaTime;
                    }
                    else if (timer > dwarfDiaDuration[5 - dwarfDiaCount])
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