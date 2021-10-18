using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = Constants.DEFAULT_ENEMY_HEALTH;
    private string IS_HIT_ANIMATION = Constants.IS_HIT_ANIM;
    private Animator anim;
    private float speed = Constants.DEFAULT_ENEMY_SPEED;

    public void Init(int health, float speed) {
        this.health = health;
        this.speed = speed;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
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
        if (hitInfo.gameObject.tag == Constants.SPAWNER_TAG)
        {
            Die();
        }
    }
}
