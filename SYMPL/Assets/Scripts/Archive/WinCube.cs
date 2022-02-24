using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCube : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public GameObject winCube;

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, 0f, Space.Self);
        transform.Translate(0f, 0f, 0f);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag=="Player")
        {
            Debug.Log("THE END");
        }
    }
}
