using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public ParticleSystem laserParticles;
    public static bool isShooting = false;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {      
        if (Input.GetButton("Shoot"))
        { 
            SetActiveLaser(true);
            isShooting = true;
        }
        else
        {
            SetActiveLaser(false);
            isShooting = false;
        }
    }

    void SetActiveLaser(bool isActive)
    {
       var emissionModule = laserParticles.emission;
       emissionModule.enabled = isActive;
    }
}