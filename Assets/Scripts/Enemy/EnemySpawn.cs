using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject baseEnemyPrefab;
    public GameObject playerTargetingEnemyPrefab;
    public List<GameObject> walls;

    public int countPerWave;

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
        //Initalize the walls list.
        walls = new List<GameObject>(); 

        //Get all the walls (PLAYERS USED AS PLACEHODLER) and add them to the walls list.
        Player[] foundObjs = FindObjectsOfType<Player>();
        foreach (Player obj in foundObjs)
        {
            walls.Add(obj.gameObject);
        }
    }

    void Update()
    {
        SpawnEnemy(playerTargetingEnemyPrefab);
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        //Constantly decrement from the timer.
        spawnTimer -= Time.deltaTime;

        //If it's time to spawn an enemy,
        if (spawnTimer <= 0)
        {
            for (int i = 0; i < countPerWave; i++)
            {
                //Set up an x and y coordinate. Make them random and ensure they're not both 0
                float randomX = 0;
                float randomY = 0;
                while (randomX == 0 && randomY == 0)
                {
                    randomX = Random.Range(-1f, 1f);
                    randomY = Random.Range(-1f, 1f);
                }
                //Now apply those coords to a normalized vector. This'll be the direction they spawn in
                Vector2 spawnDirection = new Vector2(randomX, randomY).normalized;
                //Multiply said direction by the radius. This makes it so enemies always spawn on the fringes of the spawn area
                Vector2 spawnLocation = spawnDirection * spawnAreaRadius;

                //Finally, spawn the enemy with the stuff we made.
                GameObject newEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);

                //Get the enemy script on the enemy, and set its wall reference to a random entry in the walls list.
                newEnemy.GetComponent<BaseEnemy>().wall = walls[Random.Range(0, walls.Count)];
            }

            //Reset the timer.
            spawnTimer = spawnDelay;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnAreaRadius);
    }
}
