using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float laserBeamForce = Constants.DEFAULT_LASERBEAM_FORCE;
    public int damage = Constants.DEFAULT_LASERBEAM_DAMAGE;

    public void Init(int damage, float laserBeamForce) {
        this.laserBeamForce = laserBeamForce;
        this.damage = damage;
    }

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Transform tr = GetComponent<Transform>();
        rb.AddForce(tr.up * laserBeamForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == Constants.SPAWNER_TAG)
        {
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.tag == Constants.ENEMY_TAG)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
