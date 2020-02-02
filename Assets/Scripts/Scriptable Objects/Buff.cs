using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Buff Stat list",menuName = "Scriptable Objects/Buff")]
public class Buff : ScriptableObject
{
    [Header("Buff Amounts")]
   public float health;
   public float moveSpeed;
   public float fireRate;
   public float bulletSpeed;
   public float buffTime;




    public List<float> GetStats()
    {

        List<float> stats = new List<float>();
        stats.Add(health);
        stats.Add(moveSpeed);
        stats.Add(fireRate);
        stats.Add(bulletSpeed);
        stats.Add(buffTime);

        return stats;

    }
}

