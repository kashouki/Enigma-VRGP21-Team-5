using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewoodBurn : MonoBehaviour
{
    public bool isOnFire = false;
    public bool isOnFireAndBlown = false;

    [SerializeField] ParticleSystem collectParticle = null;
    [SerializeField] ParticleSystem collectParticle_2 = null;

    private AudioSource LoopingFireSound;


    // Start is called before the first frame update
    void Start()
    {
        LoopingFireSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.gameObject.layer == 28)
        {
            collectParticle.Play();
            isOnFire = true;
            LoopingFireSound.Play();
        }

        if (other.gameObject.layer == 29 && isOnFire == true)
        {
            collectParticle_2.Play();
            isOnFireAndBlown = true;
        }





    }
}
