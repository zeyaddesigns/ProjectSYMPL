using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    
    public Rigidbody rb;
    public PlayerController script;
    
    void OnCollisionEnter(Collision other) 
        {
            if (other.gameObject.tag == "Column")
            {
                Debug.Log("ouch!");
            }
        }
}