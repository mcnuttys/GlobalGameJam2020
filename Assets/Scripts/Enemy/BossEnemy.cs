using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : PlayerTargetingEnemy
{
    [Header("Boss Settings: ")]
    public float fireRate = 1f;
    public GameObject bullet;
    public int bulletCount;
    public float bulletOffset = 1f;
    public float bulletSpeed = 5f;
    
    private float fireTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wallPosition = new Vector2(wall.transform.position.x, wall.transform.position.y);
        players = GameObject.FindObjectsOfType<Player>();

        currentPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        if (fireTimer <= 0)
        {
            fireTimer = fireRate;
            StartCoroutine(Fire());
        }

        if (fireTimer > 0)
            fireTimer -= Time.deltaTime;
    }

    IEnumerator Fire()
    {
        int bulletsCreated = 0;
        while(bulletsCreated < bulletCount)
        {
            float angle = (360f / (float)bulletCount) * bulletsCreated;
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            GameObject b = Instantiate(bullet, currentPosition + direction * bulletOffset, Quaternion.FromToRotation(Vector3.up, direction));
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            brb.velocity = direction.normalized * bulletSpeed;

            bulletsCreated++;

            yield return new WaitForSeconds(fireRate / (float)bulletCount);
        }
    }
}
