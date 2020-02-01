using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 3f;

    private Vector2 currentPosition;
    private Rigidbody2D rb;
    private Vector2 direction;

    public Vector2 Direction { get { return direction; } }
    public Vector2 Velocity { get { return rb.velocity; } }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Just convert the transform position to a vector 2
        currentPosition = new Vector2(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        // Combine our movement speed and direction multiplied by time.deltaTime so we always move the same amount.
        Vector2 move = direction * movementSpeed * Time.deltaTime;

        // To move we take our currfent position position and we add the movement.
        rb.MovePosition(currentPosition + move);
    }

    /// <summary>
    /// Have a public method to recieve the direction from the input manager.
    /// </summary>
    /// <param name="direction">The direction recieved from the input manager.</param>
    public void SetDirection(Vector2 direction)
    {
        // Normalize the recieved direction if its magnitude is too high.
        if (direction.magnitude > 1)
            direction = direction.normalized;

        this.direction = direction;
    }
}
