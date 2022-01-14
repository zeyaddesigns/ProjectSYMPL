using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float throwSpeed = 25f;

    void Update()
    {
    
        float xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * throwSpeed;
        float yThrow = Input.GetAxis("Vertical") * Time.deltaTime * throwSpeed;
        
        float newXPos = transform.localPosition.x + xThrow;
        float newYPos = transform.localPosition.y + yThrow;

        transform.localPosition = new Vector3 (newXPos, newYPos, transform.localPosition.z);

    }
}
