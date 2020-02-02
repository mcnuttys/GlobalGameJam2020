using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingEnemy : BaseEnemy
{
    public Player[] players;
    public float targetDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(wall != null)
        wallPosition = new Vector2(wall.transform.position.x, wall.transform.position.y);
        players = GameObject.FindObjectsOfType<Player>();

        currentPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindObjectsOfType<Player>();

        currentPosition = new Vector2(transform.position.x, transform.position.y);

        Death();
    }

    public override void MoveEnemy()
    {
        Player p = FindNearestPlayer();

        Vector2 move = Vector2.zero;

        if (p != null)
        {
            if (Vector2.Distance(p.Position, currentPosition) < targetDistance)
            {
                move = (p.Position - currentPosition).normalized * speed * Time.deltaTime;
            }
            else
            {
                move = (wallPosition - currentPosition).normalized * speed * Time.deltaTime;
            }
        }

        transform.up = Vector2.Lerp(transform.up, move.normalized, 25 * Time.deltaTime);

        rb.MovePosition(move + currentPosition);
    }

    public Player FindNearestPlayer()
    {
        float longestDistance = Mathf.Infinity;

        Player p = null;

        for(int i = 0; i < players.Length; i++)
        {
            float currentDistance = Vector2.Distance(transform.position, players[i].Position);

            if (currentDistance <= longestDistance)
            {
                longestDistance = currentDistance;
                p = players[i];
            }
        }

        return p;
    }

}
