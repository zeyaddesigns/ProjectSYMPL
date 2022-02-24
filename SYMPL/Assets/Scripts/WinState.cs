using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    public GameObject winCube;

    
    void Start() 
    {
        winCube.SetActive(false);    
    }

    void Update()
    {
        if (GateTrigger.goalScore==4)
        {
            Debug.Log("YOU DID IT! Now get the golden cube at the top of the tower to win the game");
            winCube.SetActive(true);
        }
    }
}
