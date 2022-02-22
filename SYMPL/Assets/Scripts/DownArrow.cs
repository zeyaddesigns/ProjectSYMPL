using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrow : MonoBehaviour
{
    
    public GameObject downArrow;
    public GameObject upArrow;
    public static bool isGravityReversed = false;

    private void OnParticleCollision(GameObject other) 
    {
        downArrow.SetActive(false);
        upArrow.SetActive(true);
        isGravityReversed = true;
        Debug.Log("Gravity Revered = " + isGravityReversed);
    }
}
