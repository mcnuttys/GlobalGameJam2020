using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //fields
    public float speed = 50f;

    private Vector2 currentPosition;
    private Rigidbody2D rb;
    public GameObject wall;
    private Vector2 wallPosition;

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
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {
        Vector2 move = wallPosition * speed * Time.deltaTime;

        rb.MovePosition(move + currentPosition);
    }

}
