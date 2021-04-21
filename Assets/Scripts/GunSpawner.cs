using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSpawner : MonoBehaviour
{
    [Tooltip("How close does the player need to be in order to trigger a gun spawn?")]
    [SerializeField]
    float activationDistance = 5f;

    [Tooltip("How long would you like to wait before triggering a new gun spawn?")]
    [SerializeField]
    int newGunDelay = 4;

    [Tooltip("Place your gun prefabs here.")]
    [SerializeField]
    GameObject[] guns = new GameObject[4];

    [Tooltip("Do you want to enable debug mode?")]
    [SerializeField]
    bool debug = false;

    bool canCreateNewGun = true;
    Transform gunSpawnLocation;
    TextMeshPro gunSpawnSign;
    string[] names = new string[] {
        "asdf", "banana gun", "Super"
    };

    void Start() {
        gunSpawnLocation = transform.GetChild(0);
        gunSpawnSign = transform.GetChild(1).GetComponent<TextMeshPro>();

        GetComponent<SphereCollider>().radius = activationDistance;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            if(canCreateNewGun) {
                StartCoroutine(SpawnGun());
            }
            else {
                if(debug) Debug.Log("You need to wait!");
            }
        }
    }

    IEnumerator SpawnGun() {
        if (debug) Debug.Log("Running SpawnGun");
        canCreateNewGun = false;
        GameObject newGun = Instantiate(guns[Random.Range(0,guns.Length)], gunSpawnLocation.position, Random.rotation);
        newGun.name = names[Random.Range(0,names.Length)];
        
        int timer = newGunDelay;
        while(timer-- > 0) {
            gunSpawnSign.text = timer.ToString();
            yield return new WaitForSeconds(1);
            
        }
        canCreateNewGun = true;
        gunSpawnSign.text = "Get Your Guns Here";
    }
}







