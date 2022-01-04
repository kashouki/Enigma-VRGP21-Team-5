using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_1 : MonoBehaviour
{
    private OVRHand hand;
    public GameObject capsule;
    public GameObject TutorialHands_1;
    public GameObject Wind_GestureDetector_Right;
    private isInArea bool_script;
    [SerializeField] ParticleSystem collectParticle = null;
    [SerializeField] ParticleSystem collectParticle_2 = null;

    public bool hasCastWind = false;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
        bool_script = capsule.GetComponent<isInArea>();
    }

    public void Burn()
    {
       collectParticle.Play();
       // If in crow trap
       if (bool_script.isInTheArea == true)
        {
            collectParticle_2.Play();
            hasCastWind = true;
            // Turn off wind magic tutorial hand
            TutorialHands_1.SetActive(false);
            // Turn on right-hand wind magic
            Wind_GestureDetector_Right.SetActive(true);
        }
        
    }



    // Update is called once per frame
    void Update()
    {

    }

   
}
