// this will tell the console what it's velocity is

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeloDebug : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.z > RBShooter.s_FastestSpeed) {
            Debug.Log("My fastest Z velocity is " + rb.velocity.z);
            RBShooter.s_FastestSpeed = rb.velocity.z;
        }
    }
}
