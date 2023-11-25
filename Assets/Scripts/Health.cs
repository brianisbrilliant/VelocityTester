using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public int health = 10;

    [SerializeField]
    float deathDuration = 4;

    enum Element {Flame, Candy, Ice, Slime, Human};        // this needs to be the same as in the Bullet class.

    [SerializeField]
    Element damageType = Element.Ice;

    [SerializeField]
    bool isPlayer = false;
    
    bool dying = false;

    [SerializeField] TextMeshPro text;
    // 0 is a strong loss of health, 1 is a regular loss of health, 2 is a gain of health.
    [SerializeField] Color32[] textColors = new Color32[3];
    [SerializeField] float textColorDuration = 0.25f;


    // This is designed to be called by a bullet and given a negative number.
    public void ChangeHealth(int byAmount = -1, int givenDamageType = 1) {
        
        // if it is the opposite type, take all the damage
        if((int)damageType == (givenDamageType + 2) % 4) {
            health += byAmount;
            StartCoroutine(ColorText(0));
        // if it is the SAME type, give health instead of taking it!
        } else if((int)damageType == givenDamageType) {
            health -= byAmount;
            StartCoroutine(ColorText(2));
        // if an enemy is damaging a human. (the player)
        } else if (damageType == Element.Human) {
            health += byAmount;
        // otherwise, take half damage.
        } else {
            health += (int)(byAmount * 0.5f);
            StartCoroutine(ColorText(1));
        }

        text.text = health.ToString();

        if(health <= 0 && !dying) {
            dying = true;
            if(isPlayer) {
                SceneManager.LoadScene(0);
                // static variables need to be reset!
                AISpawner.totalAI = 0;
            }
            else {
                try {
                    Destroy(GetComponent<MoveTo>());
                    Destroy(GetComponent<StopAndShoot>());      // stops shooting, still looks, somewhat.
                    Destroy(GetComponent<NavMeshAgent>());
                }
                catch { // catch(NullReference ex)
                    // do nothing.
                }

                Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
                AISpawner.totalAI -= 1;
                Destroy(this.gameObject, deathDuration);
                StartCoroutine(DeathAnimation());
                
            }
        }
    }

    IEnumerator DeathAnimation() {
        while(true) {
            this.transform.localScale -= Vector3.one / (deathDuration * 10);
            Debug.Log("Enemy localScale = " + this.transform.localScale);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator ColorText(int color) {
        // change color
        text.color = textColors[color];
        yield return new WaitForSeconds(textColorDuration);
        for(int i = 0; i < 10; i++) {
            text.color = Color32.Lerp(textColors[color], Color.white, i * .1f);
            yield return new WaitForEndOfFrame();
        }
        // return to white
        text.color = Color.white;
    }
}
