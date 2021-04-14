using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            anim.SetTrigger("Open Door");
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            anim.SetTrigger("Close Door");
        }
    }
}
