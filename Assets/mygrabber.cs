using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class mygrabber : OVRGrabber
{
    public GameObject potionPoisonHand;
    public GameObject potionPoison;
    public GameObject potionAntidoteHand;
    public GameObject potionAntidote;
    public GameObject knifeHand;
    public GameObject knife;
    //
    
    //
    //public GameObject normalHand;
    //private Renderer renderer;
    private OVRHand hand;
    public float pinchThreshold = 0.6f;
    public float holdThreshold = 0.5f;
    bool hold;
    protected override void Start()
    {
        //Debug.Log("START");
        base.Start();
        hand = GetComponent<OVRHand>();
        //renderer = GetComponent<Renderer>();
        hold = false;
    }
    public override void Update()
    {
        base.Update();
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        //Debug.Log("Distance from potion : " + Vector3.Distance(potionPoison.transform.position, transform.position));
        //Debug.Log("Pinch: " + pinchStrength);
        //Debug.Log("Hold: " + hold);
        if (!hold && /*!m_grabbedObj && */ pinchStrength >= pinchThreshold /*&& m_grabCandidates.Count > 0*/)
        {
            //Debug.Log("in if");
            //Debug.Log("potion : " + Vector3.Distance(potionPoison.transform.position, transform.position));
            //Debug.Log("holdthreshold= " + holdThreshold);
            if (holdThreshold > Vector3.Distance(potionPoison.transform.position, transform.position))
            {
                hold = true;
                potionPoisonHand.SetActive(true);
                potionPoison.SetActive(false);
                GetComponent<OVRMeshRenderer>().enabled = false;
                GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            else if (holdThreshold > Vector3.Distance(potionAntidote.transform.position, transform.position))
            {
                hold = true;
                potionAntidoteHand.SetActive(true);
                potionAntidote.SetActive(false);
                GetComponent<OVRMeshRenderer>().enabled = false;
                GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            else if (holdThreshold > Vector3.Distance(knife.transform.position, transform.position))
            {
                hold = true;
                knifeHand.SetActive(true);
                knife.SetActive(false);
                GetComponent<OVRMeshRenderer>().enabled = false;
                GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
        }
        else if (hold && pinchStrength < pinchThreshold)
        {
            hold = false;
            potionPoisonHand.SetActive(false);
            potionPoison.SetActive(true);
            potionAntidoteHand.SetActive(false);
            potionAntidote.SetActive(true);
            knifeHand.SetActive(false);
            knife.SetActive(true);
            GetComponent<OVRMeshRenderer>().enabled = true;
            GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
    }
}
