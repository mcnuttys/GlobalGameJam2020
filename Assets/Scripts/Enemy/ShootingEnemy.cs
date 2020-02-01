using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootingEnemy : PlayerTargetingEnemy
{

    public float shootDistance = 5.5f;
    public float shootTimer;
    public float shootMax = 1.5f;
    public float bulletSpeed = 5.0f;
    public float fireRate = 0.5f;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //wallPosition = new Vector2(wall.transform.position.x, wall.transform.position.y);
        
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        shootTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindObjectsOfType<Player>();
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        if (shootTimer < 0.0f)
        {
            Shoot();
            shootTimer = 0.3f;
        }

        //start the timer
        shootTimer -= Time.deltaTime;

        Death();
    }

    void Shoot()
    {
        Player player = FindNearestPlayer();

        if (Vector2.Distance(player.Position, currentPosition) < shootDistance)
        {
            //get the direction of the player closest to the enemy
            Vector2 direction = (player.Position - currentPosition).normalized;

            //create the bullet
            GameObject b = Instantiate(bullet, currentPosition + direction * 0.7f, Quaternion.identity);

            //get the rigidbody for the bullet
            Rigidbody2D bRB = b.GetComponent<Rigidbody2D>();

            bRB.velocity = direction * bulletSpeed;

            shootTimer = fireRate;
        }
    }
}
