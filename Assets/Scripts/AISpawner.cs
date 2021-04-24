using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    public static int totalAI = 0;

    public MoveTo[] AIPrefabs = new MoveTo[4];
    public Transform goal;
    public float interval = 2;

    void Start() {
        StartCoroutine(SpawnAI());
    }

    IEnumerator SpawnAI() {
        while(true) {
            yield return new WaitForSeconds(interval);
            if(totalAI <= 10) {
                MoveTo copy = Instantiate(AIPrefabs[Random.Range(0, AIPrefabs.Length)], 
                                                this.transform.position, 
                                                this.transform.rotation);
                copy.goal = goal;
                totalAI += 1;
            }
        }
    }
}
