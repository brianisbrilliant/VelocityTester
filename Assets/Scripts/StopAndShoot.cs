using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StopAndShoot : MonoBehaviour
{
    public Transform goal;
    [SerializeField]
    float shootingRange = 20;

    NavMeshAgent agent;
    bool goalIsVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // if agent is in range and visible
        float rangeToGoal = Vector3.Distance(transform.position, goal.position);
        // pretend the "eye" is the gun's spawner
        Transform eye = transform.GetChild(0).GetChild(0);
        RaycastHit hit;
        Debug.DrawRay(eye.position, eye.transform.forward * 20, Color.cyan, 1);
        if(Physics.Raycast(eye.position, eye.transform.forward * 20, out hit, 100)) {
            if(hit.collider.CompareTag("Player")) {
                goalIsVisible = true;
            } else {
                goalIsVisible = false;
            }
        }
        // stop moving, aim at player, shoot.
        if(rangeToGoal < shootingRange && goalIsVisible) {
            agent.destination = transform.position;     // is this right or should I remove the path? Reset the path?
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
            agent.destination = goal.position;
        }
    }
}
