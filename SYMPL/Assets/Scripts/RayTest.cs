using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public float range = 10000f;
    public float force = 5000f;
    public Rigidbody target;
    public static RaycastHit hitInfo;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        

        if (Physics.Raycast(ray, out hitInfo, range))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * range, Color.green);
        }
    }
}
