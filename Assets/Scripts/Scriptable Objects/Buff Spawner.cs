using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    //Fields
    [SerializeField] float respawnTime;
    [SerializeField] Buff buffToSpawn;
    [SerializeField] float respawnTimeElapsed;
    [SerializeField] Buff spawnedBuffInstance;
    bool buffSpawned = false;



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
                spawnedBuffInstance = Instantiate(buffToSpawn, transform.position, Quaternion.identity);
            }
        }
    }

}
