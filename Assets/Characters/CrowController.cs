using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CrowController : MonoBehaviour
{
    [System.Serializable]
    public class Sentence
    {
        public AudioClip clip;
        public float time;
        public string content;
    }

    AudioSource audioSource;
    public Sentence[] sentences;
    public bool trigger;
    public int count;
    public Animator animator;

    public ShowText DialogUI;
    public Vector3 initScale;

    public bool ShowUI;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        trigger = false;
        count = 0;
        initScale = DialogUI.transform.localScale;
        DialogUI.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            trigger = false;
            audioSource.clip = sentences[count].clip;
            if (count == 1)
            {
                animator.SetTrigger("Fly");
            }
            else
            {
                animator.SetTrigger("Clicked");
            }
            audioSource.Play();

            if (ShowUI)
            {
                DialogUI.transform.localScale = initScale;
                StartCoroutine(DialogUI.Play(sentences[count].content));
            }
            count++;
        }
    }
}
