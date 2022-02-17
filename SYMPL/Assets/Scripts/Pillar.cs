using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    
    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
       body.useGravity = false;
       body.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (Shootable.isDistroyed==true)
        {
            body.useGravity = true;
            body.constraints = RigidbodyConstraints.None;
        }
    }
}
