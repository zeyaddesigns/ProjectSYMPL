using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenShot : MonoBehaviour
{
    public float force = 10000f;
    Rigidbody rb; 
    public void OnParticleCollision(GameObject other) 
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(-RayTest.hitInfo.normal * force);
    }
}
