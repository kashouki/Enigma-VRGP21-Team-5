using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private OVRHand hand;
    [SerializeField] ParticleSystem collectParticle = null;
    [SerializeField] AudioSource magicSound = null;

    private bool isCastingMagic = false;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
    }

    public void Burn()
    {
        if (!isCastingMagic)
        {
            isCastingMagic = true;
            collectParticle.Play();
            magicSound.Play();

            StartCoroutine(RightHandMagicCoroutine());
        }



    }



    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RightHandMagicCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        isCastingMagic = false;

    }
}
