using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooglyEye : MonoBehaviour
{
    Player[] players;

    Player closestPlayer;
    private Vector2 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindObjectsOfType<Player>();
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindObjectsOfType<Player>();
        currentPosition = transform.position;

        if(players != null)
        {
            closestPlayer = FindNearestPlayer();

            Vector2 dir = closestPlayer.Position - currentPosition;

            transform.up = dir;
        }
    }

    public Player FindNearestPlayer()
    {
        float longestDistance = Mathf.Infinity;

        Player p = null;

        for (int i = 0; i < players.Length; i++)
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
