using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_2 : MonoBehaviour
{
    private OVRHand hand;
    public GameObject capsule;
    public GameObject TutorialHands_2;
    public GameObject Wind_GestureDetector_Right;
    public GameObject WindAndFire_GestureDetector_Right;
    private isInDwarfArea bool_script_2;
    [SerializeField] ParticleSystem collectParticle = null;

    public bool hasCastFire = false;
    private bool isCastingFire = false;

    private AudioSource FireSound;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
        bool_script_2 = capsule.GetComponent<isInDwarfArea>();

        FireSound = GetComponent<AudioSource>();
    }

    public void Burn()
    {
        if (!isCastingFire)
        {
            isCastingFire = true;
            collectParticle.Play();
            FireSound.Play();

            // if in dwarf area
            if (bool_script_2.isInTheDwardArea == true)
            {
                hasCastFire = true;
                // Turn off fire magic tutorial hand
                TutorialHands_2.SetActive(false);
                // Turn off right-hand wind-only magic
                Wind_GestureDetector_Right.SetActive(false);
                // Turn on right-hand wind and fire magic
                WindAndFire_GestureDetector_Right.SetActive(true);
            }

            StartCoroutine(FireCoroutine());
        }


        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        isCastingFire = false;

    }
}
