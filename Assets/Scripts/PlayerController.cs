using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Gun heldGun; 

    public Transform hand;

    Health health;

    bool canPickUp = false;
    Gun lastTouchedGun;

    void Start() {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && heldGun != null) {
            heldGun.Fire();
        }

        if(Input.GetKeyDown(KeyCode.E) && canPickUp) {
            PickUp();
        }

        if(Input.GetKeyDown(KeyCode.Q) && heldGun != null) {
            Drop();
        }

        // if() {
        //     heldGun.bulletSpeed += 50;
        // }
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Gun")) {
            try {
                lastTouchedGun = other.GetComponent<Gun>();
                canPickUp = true;
            } catch {}
            
        } 
        else if(other.CompareTag("Enemy")) {
            health.ChangeHealth();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Gun")) {
            if(lastTouchedGun != null) {
                lastTouchedGun = null;
            }
            canPickUp = false;
        }
    }

    void PickUp() {
        if(heldGun == null) {
            try {
                heldGun = lastTouchedGun;
                heldGun.transform.SetParent(hand);
                heldGun.transform.position = hand.position;
                heldGun.transform.rotation = hand.rotation;
                Destroy(heldGun.GetComponent<Rigidbody>());
                heldGun.UpdateAmmoText();

                lastTouchedGun = null;
            }
            catch {
                // do nothing.
            }
        }
    }

    void Drop() {
        heldGun.transform.Translate(Vector3.back * 2);                      // move the gun away from player's trigger
        Rigidbody gunRB = heldGun.gameObject.AddComponent<Rigidbody>();     // make it fall
        gunRB.AddRelativeForce(Vector3.back * 10, ForceMode.Impulse);
        heldGun.UpdateAmmoText(true);

        heldGun.transform.SetParent(null);                                  // stop following player
        heldGun = null;                                                     // player has no gun.
    }
}
