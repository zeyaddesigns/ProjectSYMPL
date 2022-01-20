using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour
{
    public float forwardSpeed, forwardAcceleration, slideSpeed, slideAcceleration, boostSpeed, pitchSpeed, rollSpeed, yawSpeed, rollAcceleration;
    private float activeForward, activeSlide, activeRoll, activePitch, activeYaw;

    void Update() 
    {
            
            activeForward = Mathf.Lerp(activeForward, Input.GetAxisRaw("Forward") * forwardSpeed, forwardAcceleration * Time.deltaTime);
            activeSlide = Mathf.Lerp(activeSlide, Input.GetAxisRaw("Slide") * slideSpeed, slideAcceleration * Time.deltaTime);
            transform.position += transform.forward * activeForward * Time.deltaTime;
            transform.position += transform.right * activeSlide * Time.deltaTime;

            activePitch = Mathf.Lerp(activePitch, Input.GetAxisRaw("Pitch"), rollAcceleration * Time.deltaTime);  
            activeRoll = Mathf.Lerp(activeRoll, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime); 
            activeYaw = Mathf.Lerp(activeYaw, Input.GetAxisRaw("Yaw"), rollAcceleration * Time.deltaTime); 
            transform.Rotate(-activePitch * pitchSpeed * Time.deltaTime,
                             activeYaw * yawSpeed * Time.deltaTime,
                             activeRoll * rollSpeed * Time.deltaTime, Space.Self);  

            if (Input.GetKey(KeyCode.Space))
        {
            activeForward += boostSpeed * Time.deltaTime;
        }

    }
}