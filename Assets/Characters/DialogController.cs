using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DialogController : MonoBehaviour
{
    [System.Serializable]
    public class Sentence
    {       
        public AudioClip clip;
        public float time;
    }

    AudioSource audioSource;
    public Sentence[] sentences;
    public bool trigger;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        trigger = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            trigger = false;
            audioSource.clip = sentences[count].clip;
            GetComponent<Animator>().SetTrigger("Transition");
            audioSource.Play();
            count++;
        }
    }
}
