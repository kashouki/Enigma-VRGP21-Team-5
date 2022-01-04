using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isInArea : MonoBehaviour
{
    public bool isInTheArea = false;
    public GameObject TutorialHands_1;
    public GameObject Wind_GestureDetector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If in crow trap
        if (other.gameObject.layer == 26)
        {
            isInTheArea = true;
            // Show wind magic tutorial hand
            TutorialHands_1.SetActive(true);
            // Turn on left-hand wind magic
            Wind_GestureDetector.SetActive(true);
            // Destroy(other.gameObject);
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
