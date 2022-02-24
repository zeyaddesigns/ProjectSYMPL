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
        if (!isGravityReversed && GateTrigger.goalScore >= 2)
        {
            downArrow.SetActive(false);
            upArrow.SetActive(true);
            isGravityReversed = true;
        }
    }
}
