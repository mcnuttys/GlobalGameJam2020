using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    float damaage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<Player>())
        {
            Player p = collision.transform.GetComponent<Player>();

            p.health -= 10.0f;

        }
        else if(collision.transform.GetComponent<Wall>())
        {
            Wall w = collision.transform.GetComponent<Wall>();

            w.health -= 10.0f;
            Destroy(gameObject);
        }
    }
}
