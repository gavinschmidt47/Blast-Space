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
    [SerializeField]
    private float spawnMargin = 0.1f;

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
         // Get the camera bounds
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // Adjust the camera bounds to leave room on the sides
        float adjustedCamWidth = camWidth * (1 - spawnMargin);
        float adjustedCamHeight = camHeight * (1 - spawnMargin);

        // Generate random position within camera bounds
        Vector3 randomPosition = new Vector3(Random.Range(-camWidth / 2, camWidth / 2), Random.Range(-camHeight / 2, camHeight / 2), 0);

        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}
