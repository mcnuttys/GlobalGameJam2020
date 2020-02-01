using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, ITakeDamage
{
    public float health;

 
    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damageTaken)
    {
        throw new System.NotImplementedException();
    }
}
