using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Tooltip("The bullet prefab goes here.")]
    public Rigidbody bulletPrefab;

    [Tooltip("The position to spawn the bullet at.")]
    public Transform bulletSpawn;

    [Range(20,200)]
    public float bulletSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        if(bulletSpawn == null) {
            bulletSpawn = this.transform.GetChild(0);
        }
    }

    public void Fire() {
        Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet.gameObject, 4);
    }
}
