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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Just convert the transform position to a vector 2
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        // Get the direction of movement from the input system.
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Make sure the input is not too large, by normalizing.
        if (direction.magnitude > 1)
            direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        // Combine our movement speed and direction multiplied by time.deltaTime so we always move the same amount.
        Vector2 move = direction * movementSpeed * Time.deltaTime;

        // To move we take our currfent position position and we add the movement.
        rb.MovePosition(currentPosition + move);
    }
}
