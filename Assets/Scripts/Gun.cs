using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Tooltip("The bullet prefab goes here.")]
    public Rigidbody bulletPrefab;

    [Tooltip("The position to spawn the bullet at.")]
    public Transform[] bulletSpawn;

    [Range(20,200)]
    public float bulletSpeed = 50;

    public bool final = true;

    private bool multipleSpawnPoints = false;
    private int spawnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(bulletSpawn.Length == 0) {
            bulletSpawn = new Transform[transform.childCount];
            for(int i = 0; i < transform.childCount; i++) {
                bulletSpawn[i] = transform.GetChild(i);
            }
        }
        if(bulletSpawn.Length > 1) {
            multipleSpawnPoints = true;
        }
    }

    public void Fire() {
        Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn[spawnIndex].position, bulletSpawn[spawnIndex].rotation);
        if(multipleSpawnPoints) spawnIndex =  (spawnIndex + 1) % bulletSpawn.Length;
        if(!final) bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        else {
            bullet.AddRelativeForce(Vector3.back * bulletSpeed, ForceMode.Impulse);
            bullet.transform.localScale *= 0.5f;
        }
        Destroy(bullet.gameObject, 4);
    }
}
