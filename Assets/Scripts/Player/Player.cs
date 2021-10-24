using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = Constants.PLAYER_HEALTH;
    private string IS_HIT_ANIMATION = Constants.IS_HIT_ANIM;
    private Animator anim;
    public HealthBar healthBar;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start() {
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger(IS_HIT_ANIMATION);
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void RestoreHealth(int healthBonus) {
        if (health < Constants.PLAYER_HEALTH) {
            health += healthBonus;
            healthBar.SetHealth(health);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        GameOverManager.instance.PlayerDied();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == Constants.ENEMY_TAG)
        {
            TakeDamage(Constants.DEFAULT_ENEMY_HIT_DAMAGE);
        }
        else if (hitInfo.gameObject.tag == Constants.HEALTH_BONUS_TAG) {
            RestoreHealth(Constants.HEALTH_POINT_BONUS);
        }
    }

    private void OnBecameInvisible() {
        // GameOver()
        Die();
    }
}
