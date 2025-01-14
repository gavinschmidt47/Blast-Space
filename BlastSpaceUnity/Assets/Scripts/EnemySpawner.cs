using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minSpawnTime = 1.0f;

    [SerializeField]
    private float maxSpawnTime = 3.0f;

    private float timeUntilNextSpawn;

    void Awake()
    {
        SetTimeUntilNextSpawn();
    }

    void FixedUpdate()
    {
        timeUntilNextSpawn -= Time.deltaTime;

        if (timeUntilNextSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilNextSpawn();
        }
    }

    private void SetTimeUntilNextSpawn()
    {
        timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
