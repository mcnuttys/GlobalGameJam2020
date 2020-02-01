using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 5f;
    public float bulletOffset = 0.6f;
    public float firerate = 0.5f;
    public float bulletSpeed = 5f;
    public GameObject bulletPrefab;

    private PlayerMovement pm;
    private float fireTimer;

    public Vector2 Position { get { return transform.position; } }

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer > 0)
            fireTimer -= Time.deltaTime;
    }

    public virtual void Fire(Vector2 direction)
    {
        // Make sure that the fire direction is normalized.
        direction = direction.normalized;

        if (fireTimer <= 0)
        {
            // Shoot code.
            // Create the bullet.
            GameObject bullet = Instantiate(bulletPrefab, Position + direction * bulletOffset, Quaternion.FromToRotation(Vector3.up, direction));
            
            // Get the bullets physics component.
            Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();

            // Set the bullets velocity.
            brb.velocity = direction * bulletSpeed;

            //At the end of shooting, make sure to reset the firerate.
            fireTimer = firerate;
        }
    }

    public void SetDirection(Vector2 direction)
    {
        pm.SetDirection(direction);
    }
}
