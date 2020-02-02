using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBullet : Bullet
{
    public float damage;
    public float pushFactor;

    // Start is called before the first frame update
    void Start()
    {
        soundFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method so when this bullet hits it repairs health and buildings
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.transform.GetComponent<DefendablePoints>())
            {
                DefendablePoints dp = collision.transform.parent.transform.GetComponent<DefendablePoints>();

                dp.Repair(10);
            }
        }
        if (collision.transform.GetComponent<EnemyBullet>())
        {
            Destroy(gameObject);
        }
        if (collision.transform.GetComponent<DestoryBullet>())
        {
            Destroy(gameObject);
        }
        if (collision.transform.GetComponent<Wall>())
        {
            Destroy(gameObject);
        }
        if (collision.transform.GetComponent<BaseEnemy>())
        {
            BaseEnemy b = collision.transform.GetComponent<BaseEnemy>();
            b.GetComponent<Rigidbody2D>().AddForce((b.transform.position - transform.position).normalized * pushFactor / Time.deltaTime);
            Destroy(gameObject);
        }

        base.OnCollisionEnter2D(collision);
    }
}
