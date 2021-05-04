using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Gun heldGun; 

    public Transform hand;

    Health health;

    void Start() {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && heldGun != null) {
            heldGun.Fire();
        }

        // if() {
        //     heldGun.bulletSpeed += 50;
        // }
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Gun")) {
            if(heldGun == null) {
                try {
                    heldGun = other.GetComponent<Gun>();
                    heldGun.transform.SetParent(hand);
                    heldGun.transform.position = hand.position;
                    heldGun.transform.rotation = hand.rotation;
                    heldGun.GetComponent<Rigidbody>().isKinematic = true;
                }
                catch {
                    // do nothing.
                }
            }
        } else if(other.CompareTag("Enemy")) {
            health.ChangeHealth();
        }
    }
}
