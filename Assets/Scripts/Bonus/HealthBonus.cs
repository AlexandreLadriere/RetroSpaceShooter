using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    public int healthBonus = Constants.HEALTH_POINT_BONUS;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeTimeWaiter(Constants.HEALTH_BONUS_LIFETIME));
    }

    IEnumerator LifeTimeWaiter(int lifetime) {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == Constants.PLAYER_TAG)
        {
            Destroy(gameObject);
        }
    }
}
