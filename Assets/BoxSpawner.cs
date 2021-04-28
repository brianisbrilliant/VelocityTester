using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject prefab;
    public Transform goal;
    public float xRange = 30.0f, zRange = 30.0f;


    // simple timer
    float interval = 1;
    float timer = 0;

    int elementalType = 0;      // 0, 1, 2, 3

    void Start() {
        elementalType = Random.Range(0,4);

        if(elementalType == 0) {
            // color = red
            // bullet color = red
            // bullet type is fire.
        }
        if(elementalType == 1) {
            // color = blue
            // bullet color = blue
            // bullet type is water.
        }
    }




    // Update is called once per frame
    void Update()
    {
        // simple timer 
        timer -= Time.deltaTime;
        if(timer <= 0) {
            SpawnBox();
            timer = interval;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            SpawnBox();
        }
    }

    void SpawnBox() {
        GameObject box = Instantiate(prefab, this.transform.position, this.transform.rotation);
        box.transform.Translate(Random.Range(-xRange,xRange), 1, Random.Range(-zRange,zRange));
        box.AddComponent<Rigidbody>();
        box.GetComponent<Patrol>().goal = goal;
    }

    IEnumerator Wait() {
        while(true) {
            // do the thing
            SpawnBox();
            yield return new WaitForSeconds(1);
        }
    }
}
