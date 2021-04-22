using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Tooltip("The bullet prefab goes here.")]
    [SerializeField]
    private Rigidbody bulletPrefab;

    [Tooltip("The position to spawn the bullet at.")]
    [SerializeField]
    private Transform[] bulletSpawn;

    [Range(20,200)]
    [SerializeField]
    private float bulletSpeed = 50;

    [SerializeField]
    private float interval = 0.1f;


    [SerializeField]
    private Vector2 ammoRange = new Vector2(10,20);
    private int ammo = 10;

    [SerializeField]
    private bool final = true;

    private bool multipleSpawnPoints = false;
    private int spawnIndex = 0;

    private bool canFire = true;
    

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

        ammo = (int)Random.Range(ammoRange.x, ammoRange.y);
    }

    public void Fire() {
        if(canFire) {
            if(ammo > 0) {
                ammo -= 1;
                Debug.DrawRay(bulletSpawn[spawnIndex].position, bulletSpawn[spawnIndex].forward * 5, Color.red, 1f);
                Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn[spawnIndex].position, bulletSpawn[spawnIndex].rotation);
                if(multipleSpawnPoints) spawnIndex =  (spawnIndex + 1) % bulletSpawn.Length;
                if(!final) bullet.AddRelativeForce(bulletSpawn[spawnIndex].forward * bulletSpeed, ForceMode.Impulse);
                else {
                    bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
                    bullet.transform.localScale *= 0.5f;
                }
                Destroy(bullet.gameObject, 4);
                StartCoroutine(WaitToFire());
            } else {
                Debug.Log("Out of Ammo");
                Destroy(this);
                // get the great grandparent.
                this.transform.parent.parent.parent.GetComponent<PlayerController>().heldGun = null;
                this.transform.SetParent(null);
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        
    }

    IEnumerator WaitToFire() {
        canFire = false;
        yield return new WaitForSeconds(interval);
        canFire = true;
    }
}
