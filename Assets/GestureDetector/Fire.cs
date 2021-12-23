using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private OVRHand hand;
    [SerializeField] ParticleSystem collectParticle = null;


    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
    }

    public void Burn()
    {
        collectParticle.Play();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
