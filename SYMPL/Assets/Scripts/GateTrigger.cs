using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateTrigger : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;
    public static int goalScore;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Ball")
        { 
            redLight.SetActive(false);
            greenLight.SetActive(true);
            goalScore++;
            Debug.Log("Goal Count: " + goalScore);
        }    
    }
}
