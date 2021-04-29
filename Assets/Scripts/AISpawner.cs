using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawner : MonoBehaviour
{
    public static int totalAI = 0;

    public StopAndShoot[] AIPrefabs = new StopAndShoot[4];
    public Transform goal;
    public float interval = 2;
    public int totalDesiredAI = 3;
    [SerializeField]
    Transform[] spawnPoints;

    void Start() {
        StartCoroutine(SpawnAI());
    }

    IEnumerator SpawnAI() {
        while(true) {
            yield return new WaitForSeconds(interval);
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            if(totalAI <= totalDesiredAI) {
                StopAndShoot copy = Instantiate(AIPrefabs[Random.Range(0, AIPrefabs.Length)], 
                                                point.position, 
                                                point.rotation);
                copy.goal = goal;
                totalAI += 1;
            }
        }
    }
}
