using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    float damaage;

    private void Start()
    {
        soundFX.Play();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Player>())
        {
            Player p = collision.transform.GetComponent<Player>();

            p.health -= 10.0f;

            Destroy(gameObject);
        }
        else if (collision.transform.GetComponent<Wall>())
        {
            Wall w = collision.transform.GetComponent<Wall>();

            w.health -= 10.0f;

            Destroy(gameObject);
        }
        else if (collision.transform.GetComponent<DestoryBullet>())
        {
            Destroy(gameObject);
        }
        else if (collision.transform.GetComponent<RepairBullet>())
        {
            Destroy(gameObject);
        }

        base.OnCollisionEnter2D(collision);
    }
}
