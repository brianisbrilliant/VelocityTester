using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target;

    void Start() {
        if(!target) {
            target = GameObject.Find("Player").transform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(target);
        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = 0;          // stop it looking up or down
        rot.y += 180;       // flip the text around
        transform.eulerAngles = rot;
    }
}
