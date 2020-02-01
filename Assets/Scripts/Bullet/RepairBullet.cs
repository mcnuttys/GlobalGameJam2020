using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBullet : Bullet
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method so when this bullet hits it repairs health and buildings
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Wall>()) 
        {
            Debug.Log("Detech Hit for wall");
            Wall w = collision.transform.GetComponent<Wall>();

            w.health += 10.0f;
            Debug.Log("Increased the health");
        }
    }
}
