using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public float health = 5f;
    public float bulletOffset = 0.6f;
    public float firerate = 0.5f;
    public float bulletSpeed = 5f;
    public GameObject bulletPrefab;


    private Buff currentBuff;
    float buffTime = 0;
    float buffTimeElapsed = 0;

    private PlayerMovement pm;
    private float fireTimer;

    public Vector2 Position { get { return transform.position; } }

    private Vector2 lastDirection = new Vector2(1, 0);

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

        //
        if (currentBuff != null)
        {
            buffTimeElapsed += Time.deltaTime;
            if (buffTimeElapsed >= buffTime)
            {
                RemoveBuff();
            }
        }
    }

    public virtual void Fire(Vector2 direction)
    {
        if (direction.magnitude < 0.1f)
            direction = lastDirection;

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

        lastDirection = direction;
    }

    public void SetDirection(Vector2 direction)
    {
        pm.SetDirection(direction);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Apply Buff
        if (collision.collider.CompareTag("BuffPickup"))
        {
            ApplyBuff(collision.collider.gameObject.GetComponent<BuffPickup>().BuffToPickup);
            Destroy(collision.collider.gameObject);
        }
    }

    /// <summary>
    /// Applies the picked up buff
    /// </summary>
    /// <param name="buffToApply">The buff to apply to the player</param>
    private void ApplyBuff(Buff buffToApply)
    {

       // Debug.Log("Applied Buff");
        //If there is already a buff applied to the player, remove it
        if (currentBuff != null)
        {
            RemoveBuff();
        }

        //Apply buff stats
        currentBuff = buffToApply;
        this.health += buffToApply.health;
        this.firerate -= buffToApply.fireRate;
        this.bulletSpeed += buffToApply.bulletSpeed;
        buffTime = buffToApply.buffTime;
        buffTimeElapsed = 0;

    }

    /// <summary>
    /// Removes the currently applied buff
    /// </summary>
    private void RemoveBuff()
    {
      //  Debug.Log("Remove Buff");
        if (currentBuff != null)
        {
           // this.health -= currentBuff.health;
            this.firerate += currentBuff.fireRate;
            this.bulletSpeed -= currentBuff.bulletSpeed;
            currentBuff = null;
            buffTime = 0;
            buffTimeElapsed = 0;
        }
    }
}
