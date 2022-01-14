using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float throwSpeed = 25f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -400f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }


    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlFlow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlFlow;
        float yaw   = 0f;
        float roll  = 0f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * throwSpeed;
        yThrow = Input.GetAxis("Lift") * Time.deltaTime * throwSpeed;
        float zThrow = Input.GetAxis("Vertical") * Time.deltaTime * throwSpeed;
        
        float newXPosition = transform.localPosition.x + xThrow;
        float newZPosition = transform.localPosition.z + zThrow;
        float newYPosition = transform.localPosition.y + yThrow;

        transform.localPosition = new Vector3(newXPosition, newYPosition, newZPosition);
    }
}
