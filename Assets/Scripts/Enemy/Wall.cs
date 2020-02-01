using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float health;

    private float maxHealth = 100.0f;
 
    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        Debug.Log(health);
    }

    void Update()
    {
        if(health > 100)
        {
            health = maxHealth;
        }

        Debug.Log(health); 
    }

}
