// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patrol : MonoBehaviour {

    public Transform[] points;
    public Transform goal;          // this will be the player
    public Transform eye;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start () {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();


        // Debug.Log("Distance to player: " + Vector3.Distance(this.transform.position, 
        //                                                     goal.transform.position));

        // if the player is close.
        // point a raycast at the player to see if the player is visible.
        // is the AI facing the player?
        if(GenericLook.LookFor(goal, eye, 45)) {
            // yes I can see the player
            agent.destination = goal.position;
        }
        // if all three conditions are true, agent.destination = goal.position.
        // if the player gets far away (double the activation distance)
            // start patrolling again.
        
        
        
        
        
        
        
        // create a gun that "kills" the AI
            // destroy navmesh agent
            // destroy patrol script
            // addcomponent rigidbody
    }
}