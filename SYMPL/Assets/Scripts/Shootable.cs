using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public static bool isDistroyed = false;
    private void OnParticleCollision(GameObject other) 
    {
        Destroy(gameObject);
        isDistroyed = true;
        Debug.Log(isDistroyed);
    }
}

