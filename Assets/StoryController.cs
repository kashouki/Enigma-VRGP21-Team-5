using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject playerCurrentPos;
    public GameObject initPos;
    public GameObject doorPos;
    public GameObject gatePos;
    public int gameState;



    // Start is called before the first frame update
    void Start()
    {
        gameState = 0;
        playerPos.transform.position = initPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = playerCurrentPos.transform.position;
        if (gameState == 0)
        {
            if (player.x >= doorPos.transform.position.x)
            {
                Debug.Log("At door.");
                playerPos.transform.position = gatePos.transform.position;
                gameState = 1;
            }
        }
    }
}
