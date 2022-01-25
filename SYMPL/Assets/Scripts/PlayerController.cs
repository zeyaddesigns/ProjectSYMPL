using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed, forwardAcceleration, slideSpeed, slideAcceleration, 
                 boostSpeed, pitchSpeed, rollSpeed, yawSpeed, rollAcceleration, 
                 focalLength, activeFocalLength, boostFocalLength;
    private float activeForward, activeSlide, activeRoll, activePitch, activeYaw;
    public CinemachineVirtualCamera vcam;

    void Update()
    {
        LinearMovement();
        AngularMovement();
        boostIsActive();
    }

    private void AngularMovement()
    {
        activePitch = Mathf.Lerp(activePitch, Input.GetAxisRaw("Pitch"), rollAcceleration * Time.deltaTime);
        activeRoll = Mathf.Lerp(activeRoll, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        activeYaw = Mathf.Lerp(activeYaw, Input.GetAxisRaw("Yaw"), rollAcceleration * Time.deltaTime);
        transform.Rotate(-activePitch * pitchSpeed * Time.deltaTime,
                         activeYaw * yawSpeed * Time.deltaTime,
                         activeRoll * rollSpeed * Time.deltaTime, Space.Self);
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