using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadMovement : MonoBehaviour
{
    
    PlayerControls controls;
    public float forwardSpeed, forwardAcceleration;
    private float activeForward;

    void Awake() 
    {
        controls = new PlayerControls();
        controls.Gameplay.Forward.performed += ctx => forward();
    }

    void forward()
    {
        activeForward = Mathf.Lerp(activeForward, Input.GetAxisRaw("Forward") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        transform.position += transform.forward * activeForward * Time.deltaTime;
    }

    void OnEnable() 
    {
        controls.Gameplay.Enable();    
    }
    
    void OnDisable() 
    {
        controls.Gameplay.Disable();    
    }
}