using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    private string IS_HIT_ANIMATION = "isHit";
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage) {
        health -= damage;
        anim.SetTrigger(IS_HIT_ANIMATION);
        if(health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
}
