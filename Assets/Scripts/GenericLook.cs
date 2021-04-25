using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericLook : MonoBehaviour
{
    /* 
        please provide the following:
        target: what to look for. Example - FPSController
        fromEye: where to draw the ray from. Example - the eye of the camera or AI
        fov: the field of view possible. Example - 60 degrees in either direction for 120 total field of view
        tag: the tag to look for collision with. Example - "Player"
    */

    public static bool LookFor(Transform target, Transform fromEye, float fov = 60, string tag = "Player") {
        Vector3 rayDirection = target.position - fromEye.transform.position;
        float angle = Vector3.Angle(rayDirection, fromEye.forward);

        Debug.DrawRay(fromEye.position, fromEye.forward * 5);
        Debug.DrawRay(fromEye.position, rayDirection, angle < fov ? Color.green : Color.red);
        Debug.Log("Angle to player: " + angle);

        RaycastHit hit;
        if(Physics.Raycast(fromEye.position, rayDirection, out hit, 100)) {
            if(hit.collider.CompareTag(tag)) {
                if(angle < fov) {
                    return true;
                }
            }
        }

        return false;
    }
}
