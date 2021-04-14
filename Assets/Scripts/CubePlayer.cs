using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this makes sure we have a rigidbody component.
[RequireComponent(typeof(Rigidbody))]
public class CubePlayer : MonoBehaviour
{

    // a reference to our rigidbody
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // set rigidbody drag to 5.
        // freeze position on y
        // freeze rotation on x, y, and z
        rb.AddForce(Input.GetAxis("Horizontal") * 50, 0, Input.GetAxis("Vertical") * 50);
    }
}
