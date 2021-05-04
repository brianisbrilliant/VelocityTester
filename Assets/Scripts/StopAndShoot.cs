using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StopAndShoot : MonoBehaviour
{
    public Transform goal;
    [SerializeField]
    float shootingRange = 20, originalSpeed;

    NavMeshAgent agent;
    Gun gun;
    Transform eye;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalSpeed = agent.speed;
        agent.destination = goal.position;
        gun = transform.GetChild(0).GetComponent<Gun>();

        // pretend the "eye" is the gun's spawner
        eye = gun.transform.GetChild(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, goal.position);
        Debug.Log("distance: " + distance);
        // if agent is in range and visible
        
        // stop moving, aim at player, shoot.
        if(distance < shootingRange && GenericLook.LookFor(goal, eye)) {
            // agent.destination = transform.position;     // is this right or should I remove the path? Reset the path?
            agent.speed = 0;
            // how do I get the AI to still look towards the player?
            // don't let the navmeshagent affect the rotation.
            agent.updateRotation = false;


            Vector3 direction = (goal.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 360);
            
            // don't start moving again until you have shot twice
            gun.Fire();

        }
        else {
            agent.updateRotation = true;
            agent.speed = originalSpeed;
            agent.destination = goal.position;
        }
    }
}
