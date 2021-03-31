using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{

    public float moveSpeed = 10, jumpSpeed = 5;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void FixedUpdate() {
        rb.AddForce(Vector3.right * moveSpeed);


        if(!isGrounded && rb.velocity.y <= 0) {
            rb.AddForce(Vector3.down * jumpSpeed);
        } 

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Floor")) {
            isGrounded = true;
        }
    }

    void Jump() {
        if(isGrounded) {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
