using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour
{
    public int index;
    public bool isTouched;

    private void Start()
    {
        isTouched = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isTouched)
        {
            isTouched = true;
            Debug.Log("Swtich Scene");
            StartCoroutine(LoadYourAsync());
        }


    }
    IEnumerator LoadYourAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone)
        { 
            yield return null;
        }
    }
}
