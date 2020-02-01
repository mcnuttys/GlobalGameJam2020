using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //fields
    public float speed = 3.0f;

    private Vector2 currentPosition;
    private Rigidbody2D rb;
    public GameObject wall;
    private Vector2 wallPosition;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wallPosition = new Vector2(wall.transform.position.x, wall.transform.position.y);
        wallPosition = wallPosition.normalized;

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
    public void MoveEnemy()
    {
        Vector2 move = wallPosition  * speed * Time.deltaTime;

        rb.MovePosition(move + currentPosition);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<Wall>())
        {
            Wall w = collision.transform.GetComponent<Wall>();

            w.health -= 10;

            Destroy(gameObject);
        }

    }

    public void Death()
    {
        if(health == 0.0f)
        {
            Destroy(gameObject);
        }
    }

}
