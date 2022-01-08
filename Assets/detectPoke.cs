using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class detectPoke : MonoBehaviour
{
    // Start is called before the first frame update
    public bool poked;
    public dip D;
    public cauidron c;
    void Start()
    {
        poked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!D.dipping)
            return;
        if (other.name == "HorrorDoll")
        {
            Debug.Log("PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPoke");
            poked = true;
            if (c.status == 1)
            {
                Debug.Log("Change to GGGGGGGGGGGGGGGGGGGGGGood");
                StartCoroutine(LoadYourAsync(2));
            }
            else if (c.status == 2)
            {
                Debug.Log("Change to BBBBBBBBBBBBBBBBBBBBBBad");
                StartCoroutine(LoadYourAsync(3));
            }
            else
                Debug.Log("EEEEEEEEEEEEEEEEEEEEError");
        }
    }
    IEnumerator LoadYourAsync(int index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}