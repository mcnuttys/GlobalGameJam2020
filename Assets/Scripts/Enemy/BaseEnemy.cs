﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //fields
    public float speed = 3.0f;
    public float health;

    protected Vector2 currentPosition;
    protected Rigidbody2D rb;
    public GameObject wall;
    protected Vector2 wallPosition;
    protected float pushFactor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wallPosition = new Vector2(wall.transform.position.x, wall.transform.position.y);

        currentPosition = new Vector2(transform.position.x, transform.position.y);

        rb.angularVelocity = Random.Range(100, 500);

        pushFactor = 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        //check if the enemy is still alive
        Death();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    //method to move the enemy
    public virtual void MoveEnemy()
    {
        Vector2 move = (wallPosition - currentPosition).normalized  * speed * Time.deltaTime;
        
        rb.MovePosition(move + currentPosition);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<Wall>())
        {
            Wall w = collision.transform.GetComponent<Wall>();

            w.health -= 10.0f;

            Destroy(gameObject);
        }

        if (collision.transform.GetComponent<Player>())
        {
            pushFactor = 10;
            Player p = collision.transform.GetComponent<Player>();
            p.GetComponent<Rigidbody2D>().AddForce((p.transform.position - transform.position).normalized * pushFactor / Time.deltaTime);
        }

    }

    public void Death()
    {
        if(health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

}
