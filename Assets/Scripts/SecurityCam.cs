using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{
    public Transform rayEmitter;

    private RaycastHit hit;
    private Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if(Physics.Raycast(rayEmitter.position, transform.forward, out hit)) {
            if(hit.collider.CompareTag("Player")) {
                rend.material.color = Color.red;
                Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.red, 1);
            } else {
                rend.material.color = Color.green;
                Debug.DrawRay(rayEmitter.position, transform.forward * 10, Color.green, 1);
            }

            Debug.Log("I have hit " + hit.collider.name);
        }

        
    }
}
