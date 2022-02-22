using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArrow : MonoBehaviour
{
    public GameObject downArrow;
    public GameObject upArrow;
   
    private void OnParticleCollision(GameObject other) 
    {
        if (DownArrow.isGravityReversed==true)
        {
            upArrow.SetActive(false);
            downArrow.SetActive(true);
            DownArrow.isGravityReversed = false;
            Debug.Log("Gravity Revered = " + DownArrow.isGravityReversed);
        }
    }
}
