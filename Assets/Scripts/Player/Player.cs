using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = Constants.PLAYER_HEALTH;
    private string IS_HIT_ANIMATION = Constants.IS_HIT_ANIM;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger(IS_HIT_ANIMATION);
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == Constants.ENEMY_TAG)
        {
            TakeDamage(Constants.DEFAULT_ENEMY_HIT_DAMAGE);
        }
    }

    private void OnBecameInvisible() {
        // GameOver()
        Die();
    }
}
