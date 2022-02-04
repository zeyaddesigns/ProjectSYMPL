using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Linear Movement")]
    public float forwardSpeed;
    public float forwardAcceleration;
    public float slideSpeed;
    public float slideAcceleration;
    public float boostSpeed;
    [Header("Angular Movement")]
    public float pitchSpeed;
    public float rollSpeed;
    public float yawSpeed; 
    public float rollAcceleration;
    [Header("Camera Motion Perspective")]
    [Tooltip("When static")] public float focalLength;
    [Tooltip("When moving forward")] public float activeFocalLength; 
    [Tooltip("When boos is active")] public float boostFocalLength;
    [Header("References")]
    public CinemachineVirtualCamera vcam;
    public GameObject laser;
    public GameObject followTarget;
    public ParticleSystem laserParticles;

    private float activeForward, activeSlide, activeRoll, activePitch, activeCameraPitch, activeYaw;

    void Update()
    {
        LinearMovement();
        AngularMovement();
        boostIsActive();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButton("Shoot"))
        {
            SetActiveLaser(true);
        }
        else
        {
            SetActiveLaser(false);
        }
    }

    void SetActiveLaser(bool isActive)
    {
       var emissionModule = laserParticles.emission;
       emissionModule.enabled = isActive;
    }
    

    void AngularMovement()
    {
        activePitch = 0f; //Mathf.Lerp(activePitch, Input.GetAxisRaw("Pitch"), rollAcceleration * Time.deltaTime);
        activeRoll = 0f; //Mathf.Lerp(activeRoll, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        activeYaw = Mathf.Lerp(activeYaw, Input.GetAxisRaw("Yaw"), rollAcceleration * Time.deltaTime);
        transform.Rotate(-activePitch * pitchSpeed * Time.deltaTime,
                         activeYaw * yawSpeed * Time.deltaTime,
                         activeRoll * rollSpeed * Time.deltaTime, Space.Self);

        activeCameraPitch = Mathf.Lerp(activePitch, Input.GetAxisRaw("Pitch"), rollAcceleration * Time.deltaTime);
        followTarget.transform.Rotate(-activeCameraPitch * pitchSpeed * Time.deltaTime, 0f, 0f);
    }

    void LinearMovement()
    {
        activeForward = Mathf.Lerp(activeForward, Input.GetAxisRaw("Forward") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeSlide = Mathf.Lerp(activeSlide, Input.GetAxisRaw("Slide") * slideSpeed, slideAcceleration * Time.deltaTime);
        transform.position += transform.forward * activeForward * Time.deltaTime;
        transform.position += transform.right * activeSlide * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, FocalLengthToFOV(activeFocalLength), Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) && boostIsActive())
        {
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, FocalLengthToFOV(boostFocalLength), Time.deltaTime);
        }
    }

    public bool boostIsActive()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            activeForward += boostSpeed * Time.deltaTime;
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, FocalLengthToFOV(boostFocalLength), Time.deltaTime);
            return true;
        }
        else 
        {
            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, FocalLengthToFOV(focalLength), Time.deltaTime);
            return false;
        }
    }

    private float FocalLengthToFOV(float focalLength)
        {
            return Mathf.Rad2Deg * 2.0f * Mathf.Atan(vcam.m_Lens.SensorSize.y * 0.5f / focalLength);
        }
}