using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject baseEnemyPrefab;
    public GameObject playerTargetingEnemyPrefab;

    /// <summary>
    /// The radius of the circular area the enemies spawn in.
    /// </summary>
    [SerializeField] private float spawnAreaRadius;
    /// <summary>
    /// The time between enemy spawns.
    /// </summary>
    [SerializeField] private float spawnDelay;

    private float spawnTimer;

    void Start()
    {

    }

    void Update()
    {
        SpawnEnemy(baseEnemyPrefab);
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        //Constantly decrement from the timer.
        spawnTimer -= Time.deltaTime;

        //If it's time to spawn an enemy,
        if (spawnTimer <= 0)
        {
            //Set up an x and y coordinate. Make them random and ensure they're not both 0
            float randomX = 0;
            float randomY = 0;
            while (randomX == 0 && randomY == 0)
            {
                randomX = Random.Range(-1, 1);
                randomY = Random.Range(-1, 1);
            }
            //Now apply those coords to a normalized vector. This'll be the direction they spawn in
            Vector2 spawnDirection = new Vector2(randomX, randomY).normalized;
            //Multiply said direction by the radius. This makes it so enemies always spawn on the fringes of the spawn area
            Vector2 spawnLocation = spawnDirection * spawnAreaRadius;

            //Finally, spawn the enemy with the stuff we made.
            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);

            //Reset the timer.
            spawnTimer = spawnDelay;
        }
    }
}
