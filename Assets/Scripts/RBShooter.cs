// Brian Foster
// Testing the velocity limits of Unity's Rigidbody component

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RBShooter : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    [Range(50,5000)]
    public float bulletSpeed = 100;
    public TextMesh bulletSpeedText;
    public Text fastestTimeText;
    static public float s_FastestSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Fire();
            Debug.Log("Fire!");
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            AdjustSpeed(100);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            AdjustSpeed(-50);
        }

        fastestTimeText.text = "Fastest Time " + s_FastestSpeed.ToString("0");
    }

    public void Fire() {
        Rigidbody bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.AddRelativeForce(Vector3.up * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet.gameObject, 2);
    }

    public void AdjustSpeed(int givenChange) {
        bulletSpeed += givenChange;
        bulletSpeedText.text = bulletSpeed.ToString();
    }
}
