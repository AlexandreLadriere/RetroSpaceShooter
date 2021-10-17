using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyReference;
    [SerializeField]
    private Transform topSpawner, rightSpawner, bottomSpawner, leftSpawner;
    private GameObject spawnedEnemy;
    private GameObject spawnedHealthBonus;
    [SerializeField]
    private GameObject healthBonusPrefab;
    private int randomEnemyIndex;
    private int randomSpawnerIndex;
    private int angleShift = Constants.SPAWNER_ANGLE_SHIT;
    private int excludedMaxTimeToWaitEnemy = Constants.SPAWNER_MAX_TIME_TO_WAIT_ENEMY;
    private int excludedMaxTimeToWaitHealthBonus = Constants.SPAWNER_MAX_TIME_TO_WAIT_HEALTH_BONUS;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnHealthBonus());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        { // While true for now, but will be replaced with real condition after
            yield return new WaitForSeconds(Random.Range(1, excludedMaxTimeToWaitEnemy));
            randomEnemyIndex = Random.Range(0, enemyReference.Length);
            randomSpawnerIndex = Random.Range(0, 4);
            spawnedEnemy = Instantiate(enemyReference[randomEnemyIndex]);

            switch (randomSpawnerIndex)
            {
                case 0: // Top Spawner
                    int randomQuarter = Random.Range(0, 2);
                    // Between 90° and 180°
                    if (randomQuarter == 0)
                    {
                        spawnedEnemy.transform.eulerAngles = new Vector3(0, 0, Random.Range(90 + angleShift, 180 - angleShift));
                    }
                    // Between -180° and -90°
                    else
                    {
                        spawnedEnemy.transform.eulerAngles = new Vector3(0, 0, Random.Range(-180 + angleShift, -90 - angleShift));
                    }
                    spawnedEnemy.transform.position = new Vector3(Random.Range(leftSpawner.position.x, rightSpawner.position.x), topSpawner.position.y, 0);
                    break;
                case 1: // Right Spawner
                        // Between 0° and 180°
                    spawnedEnemy.transform.eulerAngles = new Vector3(0, 0, Random.Range(0 + angleShift, 180 - angleShift));
                    spawnedEnemy.transform.position = new Vector3(rightSpawner.position.x, Random.Range(bottomSpawner.position.y, topSpawner.position.y), 0);
                    break;
                case 2: // Bottom Spawner
                        // Between -90° and 90°
                    spawnedEnemy.transform.eulerAngles = new Vector3(0, 0, Random.Range(-90 + angleShift, 90 - angleShift));
                    spawnedEnemy.transform.position = new Vector3(Random.Range(leftSpawner.position.x, rightSpawner.position.x), bottomSpawner.position.y, 0);
                    break;
                case 3: // Left Spawner
                        // Between -180° and 0°
                    spawnedEnemy.transform.eulerAngles = new Vector3(0, 0, Random.Range(-180 + angleShift, 0 - angleShift));
                    spawnedEnemy.transform.position = new Vector3(leftSpawner.position.x, Random.Range(bottomSpawner.position.y, topSpawner.position.y), 0);
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator SpawnHealthBonus()
    {
        while (true) {
            // While true for now, but will be replaced with real condition after
            yield return new WaitForSeconds(Random.Range(1, excludedMaxTimeToWaitHealthBonus));
            float xPosition = Random.Range(leftSpawner.position.x, rightSpawner.position.x);
            float yPosition = Random.Range(bottomSpawner.position.y, topSpawner.position.y);
            spawnedHealthBonus = Instantiate(healthBonusPrefab);
            spawnedHealthBonus.transform.position = new Vector3(xPosition, yPosition, 0);
        }
    }
}
