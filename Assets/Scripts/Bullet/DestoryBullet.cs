using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBullet : Bullet
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

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<BaseEnemy>())
        {
            BaseEnemy b = collision.transform.GetComponent<BaseEnemy>();
            b.health -= damage;
            Destroy(gameObject);
        }
        if (collision.transform.GetComponent<PlayerTargetingEnemy>())
        {
            PlayerTargetingEnemy tg = collision.transform.GetComponent<PlayerTargetingEnemy>();
            tg.health -= damage;
            Destroy(gameObject);
        }
        if (collision.transform.GetComponent<ShootingEnemy>())
        {

            ShootingEnemy se = collision.transform.GetComponent<ShootingEnemy>();
            se.health -= damage;
            Destroy(gameObject);
        }
        if(collision.transform.GetComponent<BossEnemy>())
        {
            BossEnemy be = collision.transform.GetComponent<BossEnemy>();
            be.health -= damage;
            Destroy(gameObject);
        }
        if(collision.transform.GetComponent<EnemyBullet>())
        {
            EnemyBullet eb = collision.transform.GetComponent<EnemyBullet>();
            Destroy(gameObject);
        }
        if(collision.transform.GetComponent<Wall>())
        {
            Destroy(gameObject);
        }
        else if(collision.transform.GetComponent<RepairBullet>())
        {
            Destroy(gameObject);
        }
        
    }
}
