using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInDwarfArea : MonoBehaviour
{
    public bool isInTheDwardArea = false;
    public GameObject TutorialHands_2;
    public GameObject Wind_GestureDetector;
    public GameObject WindAndFire_GestureDetector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If in dwarf area
        if (other.gameObject.layer == 25)
        {
            isInTheDwardArea = true;
            // Show fire magic tutorial hand
            TutorialHands_2.SetActive(true);
            // Turn off wind-only magic
            Wind_GestureDetector.SetActive(false);
            // Turn on left-hand wind and fire magic
            WindAndFire_GestureDetector.SetActive(true);
            // Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
