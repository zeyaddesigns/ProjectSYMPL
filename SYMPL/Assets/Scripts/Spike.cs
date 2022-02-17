using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private float spikeHieght = 4000f;
    private Vector3 thrust;
    private bool playerIsVisiable = false;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("I can see you");
            playerIsVisiable = true;
            transform.Translate(0f, spikeHieght, 0f);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            transform.Translate(0f, -spikeHieght, 0f);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        Debug.Log("OUCH");    
    }
}
