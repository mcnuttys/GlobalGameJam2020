using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBullet : Bullet
{
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
        if(collision.transform.GetComponent<BaseEnemy>())
        {
            BaseEnemy b = collision.transform.GetComponent<BaseEnemy>();
            b.health -= 10.0f;
        }
        base.OnCollisionEnter2D(collision);
    }
}
