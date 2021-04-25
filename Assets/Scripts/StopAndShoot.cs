using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StopAndShoot : MonoBehaviour
{
    public Transform goal;
    [SerializeField]
    float shootingRange = 20, originalSpeed;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalSpeed = agent.speed;
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, goal.position);
        Debug.Log("distance: " + distance);
        // if agent is in range and visible
        // pretend the "eye" is the gun's spawner
        Transform eye = transform.GetChild(0).GetChild(0);
        
        // stop moving, aim at player, shoot.
        if(distance < shootingRange && GenericLook.LookFor(goal, eye)) {
            // agent.destination = transform.position;     // is this right or should I remove the path? Reset the path?
            agent.speed = 0;
            // how do I get the AI to still look towards the player?
            agent.updateRotation = false;

            var targetPosition = goal.position;
            var targetPoint = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            var _direction = (targetPoint - transform.position).normalized;
            var _lookRotation = Quaternion.LookRotation(_direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, 360);
            // don't start moving again until you have shot twice

        }
        else {
            agent.updateRotation = true;
            agent.speed = originalSpeed;
            agent.destination = goal.position;
        }
    }
}
