using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : MonoBehaviour
{
    public Transform player;
    public bool canSeePlayer;
    public float fieldOfView = 60;

    // Update is called once per frame
    void Update()
    {
        Vector3 rayDirection = player.position - this.transform.position;
        float angle = Vector3.Angle(rayDirection, transform.forward);

        if(angle < fieldOfView) canSeePlayer = true;
            // this isn't actually true, we haven't sent a ray to see if there's a wall between us yet. 

        Debug.DrawRay(this.transform.position, transform.forward * 5);
        Debug.DrawRay(this.transform.position, rayDirection, canSeePlayer ? Color.green : Color.red);
        Debug.Log("Angle to player: " + angle);
        
    }
}
