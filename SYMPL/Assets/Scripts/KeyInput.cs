using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    public GameObject downArrow;
    public GameObject upArrow;
    
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Z) && !DownArrow.isGravityReversed && GateTrigger.goalScore >= 2)
        {
            downArrow.SetActive(false);
            upArrow.SetActive(true);
            DownArrow.isGravityReversed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && DownArrow.isGravityReversed)
        {
            upArrow.SetActive(false);
            downArrow.SetActive(true);
            DownArrow.isGravityReversed = false;
        }
    }
}
