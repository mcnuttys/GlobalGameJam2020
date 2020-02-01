using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Player 1 is the keyboard input, and player 2 is the controller input.
    public Player p1;
    public Player p2;

    // The specific players cameras.
    public Camera p1Cam;
    public Camera p2Cam;

    // Update is called once per frame
    void Update()
    {
        // Set the keyboard players input.
        p1.SetDirection(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        // set the controller players input. (since no input just follow the other player.
        

        // If we get the players shoot key then we want to fire.
        if (Input.GetMouseButton(0))
        {
            // Determine the direction of the shot based off the mouse.
            Vector2 mPos = p1Cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mPos - p1.Position;
            
            // Call p1's fire code.
            p1.Fire(dir);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 mPos = p2Cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mPos - p2.Position;

            // Call p2's fire code.
            p2.Fire(dir);
        }
    }
}
