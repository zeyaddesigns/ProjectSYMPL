using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    public GameObject downArrow;
    public GameObject upArrow;
    
    void Update() 
    {
        if (Input.GetKey(KeyCode.Z) && !DownArrow.isGravityReversed)
        {
            downArrow.SetActive(false);
            upArrow.SetActive(true);
            DownArrow.isGravityReversed = true;
        }
        else if (Input.GetKey(KeyCode.Z) && DownArrow.isGravityReversed)
        {
            upArrow.SetActive(false);
            downArrow.SetActive(true);
            DownArrow.isGravityReversed = false;
        }
    }
}
