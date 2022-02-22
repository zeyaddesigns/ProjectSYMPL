using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    void FixedUpdate() 
    {
        if (DownArrow.isGravityReversed == true)
        {
            Physics.gravity = new Vector3(0f, 1000f, 0f);
        }
        else if (DownArrow.isGravityReversed == false) 
        {
            Physics.gravity = new Vector3(0f, -1000f, 0f);
        }
    }
}
