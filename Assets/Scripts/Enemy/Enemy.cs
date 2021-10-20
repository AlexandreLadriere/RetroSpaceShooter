using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = Constants.DEFAULT_ENEMY_HEALTH;
    private string IS_HIT_ANIMATION = Constants.IS_HIT_ANIM;
    private Animator anim;
    private float speed = Constants.DEFAULT_ENEMY_SPEED;
    private int killScore = Constants.DEFAULT_ENEMY_SCORE;

    public void Init(int health, float speed, int killScore) {
        this.health = health;
        this.speed = speed;
        this.killScore = killScore;
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
        ScoreManager.instance.increaseScore(Constants.DEFAULT_ENEMY_SCORE);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == Constants.SPAWNER_TAG)
        {
            Destroy(gameObject);
        }
    }
}
