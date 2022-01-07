using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_1 : MonoBehaviour
{
    private OVRHand hand;
    public GameObject capsule;
    public GameObject TutorialHands_1;
    public GameObject Wind_GestureDetector_Right;
    public GameObject whirlMagic;
    private isInArea bool_script;
    [SerializeField] ParticleSystem collectParticle = null;
    [SerializeField] ParticleSystem collectParticle_2 = null;

    public bool hasCastWind = false;
    private bool isCastingWind = false;

    private AudioSource WindSound;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
        bool_script = capsule.GetComponent<isInArea>();

        WindSound = GetComponent<AudioSource>();
        WindSound.time = 1.0f;
    }

    public void Burn()
    {
        if (!isCastingWind)
        {
            isCastingWind = true;
            collectParticle.Play();
            WindSound.Play();

            // If in crow trap
            if (bool_script.isInTheArea == true)
            {
                collectParticle_2.Play();
                
                // Turn off wind magic tutorial hand
                TutorialHands_1.SetActive(false);
                // Turn on right-hand wind magic
                Wind_GestureDetector_Right.SetActive(true);
                StartCoroutine(EscapeCoroutine());
            }

            StartCoroutine(WindCoroutine());
            
            
        }

        

    }



    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator WindCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        isCastingWind = false;

    }

    IEnumerator EscapeCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        hasCastWind = true;
        whirlMagic.SetActive(false);

    }


}
