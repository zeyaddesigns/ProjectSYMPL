using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Ball")
        {
            Debug.Log("GOAL!");
            redLight.SetActive(false);
            greenLight.SetActive(true);
        }    
    }
}
