using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;           // don't forget this!

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTo : MonoBehaviour
{
    public Transform goal;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = goal.position;
    }
}
