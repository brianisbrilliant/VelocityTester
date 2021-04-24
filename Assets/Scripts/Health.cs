using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int health = 10;

    enum Element {Flame, Candy, Ice, Slime, Human};        // this needs to be the same as in the Bullet class.

    [SerializeField]
    Element damageType = Element.Ice;

    [SerializeField]
    bool isPlayer = false;

    // This is designed to be called by a bullet and given a negative number.
    public void ChangeHealth(int byAmount = -1, int givenDamageType = 1) {
        
        // if it is the opposite type, take all the damage
        if((int)damageType == (givenDamageType + 2) % 4) {
            health += byAmount;
        // if it is the SAME type, give health instead of taking it!
        } else if((int)damageType == givenDamageType) {
            health += byAmount;
        // if an enemy is damaging a human. (the player)
        } else if (damageType == Element.Human) {
            health += byAmount;
        // otherwise, take half damage.
        } else {
            health += (int)(byAmount * 0.5f);
        }
        


        if(health <= 0) {
            if(isPlayer) {
                Application.LoadLevel(0);
                
            }
            else {
                Destroy(this);
                // if(GetComponent<NavMeshAgent>() != null) {
                //     Destroy(GetComponent<NavMeshAgent>());
                // }
                try {
                    Destroy(GetComponent<MoveTo>());
                    Destroy(GetComponent<NavMeshAgent>());
                }
                catch (NullReferenceException ex) {
                    // do nothing.
                }

                Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
                AISpawner.totalAI -= 1;
                Destroy(this.gameObject, 4);
            }
        }
    }
}
