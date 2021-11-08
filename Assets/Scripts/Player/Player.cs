using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }
    private int health = Constants.PLAYER_HEALTH;
    private string IS_HIT_ANIMATION = Constants.IS_HIT_ANIM;
    private Animator anim;
    public HealthBar healthBar;
    public PlayerInput playerInput;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
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
        if (this != null) {
            GameOverManager.instance.PlayerDied();
            Destroy(gameObject);
        }
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

    public void DisablePlayerInput() {
        playerInput.actions["Shooting"].Disable();
    }

    public void EnablePlayerInput() {
        playerInput.actions["Shooting"].Enable();
    }
}
