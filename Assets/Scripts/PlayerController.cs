using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Gun heldGun; 

    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            heldGun.Fire();
        }

        // if() {
        //     heldGun.bulletSpeed += 50;
        // }
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Gun")) {
            if(heldGun == null) {
                heldGun = other.GetComponent<Gun>();
                heldGun.transform.SetParent(hand);
                heldGun.transform.position = hand.position;
                heldGun.transform.rotation = hand.rotation;
                heldGun.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
