using System;       // this is required to use the nullrefexception.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    int damage = 5;

    enum Element {Flame, Candy, Ice, Slime};        // this needs to be the same as in the Health class.

    [SerializeField]
    Element damageType = Element.Ice;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")) {
            Health h;
            try {
                h = other.gameObject.GetComponent<Health>();
                h.ChangeHealth(-damage, (int)damageType);
            }
            catch(NullReferenceException ex) {          // can I leave out the condition?
                // do nothing
            }


            Destroy(this.gameObject);
        }
    }
}
