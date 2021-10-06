using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float laserBeamForce = 20f;
    public int damage = 50;
    private void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Transform tr = GetComponent<Transform>();
        rb.AddForce(tr.up * laserBeamForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
