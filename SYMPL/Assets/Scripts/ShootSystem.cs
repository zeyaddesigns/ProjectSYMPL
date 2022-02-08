using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public float range = 10000f;
    public ParticleSystem laserParticles;

    void Update()
    {
        Shoot();
        test();
    }

    void test()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, range))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            Debug.Log(hitInfo.transform.name);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * range, Color.green);
        }

    }

    void Shoot()
    {      
        if (Input.GetButton("Shoot"))
        {SetActiveLaser(true);}
        else
        {SetActiveLaser(false);}
    }

    void SetActiveLaser(bool isActive)
    {
       var emissionModule = laserParticles.emission;
       emissionModule.enabled = isActive;
    }
}