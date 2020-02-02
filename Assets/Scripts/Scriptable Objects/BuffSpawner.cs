using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    //Fields
    [SerializeField] float respawnTime;
    [SerializeField] GameObject buffToSpawn;
    [SerializeField] float respawnTimeElapsed;
    [SerializeField] GameObject spawnedBuffInstance;
    bool buffSpawned = false;

    private void Start()
    {
        spawnedBuffInstance = Instantiate(buffToSpawn, transform.position, Quaternion.identity);
    }

    //Methods
    private void Update()
    {
        if(spawnedBuffInstance == null)
        {
            buffSpawned = false;
        }
        else
        {
            buffSpawned = true;
            respawnTimeElapsed = 0;
        }

        //Spawn Stuff
        if(buffSpawned == false)
        {
            respawnTimeElapsed += Time.deltaTime;

            if (respawnTimeElapsed >= respawnTime)
            {
                //Spawn new Buff
                spawnedBuffInstance = Instantiate(buffToSpawn, this.transform.position, Quaternion.identity);
            }
        }
    }

}
