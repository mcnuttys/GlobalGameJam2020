using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Player 1 is the keyboard input, and player 2 is the controller input.
    public Player p1;
    public Player p2;

    // The specific players cameras.
    public CameraManager cameraManager;
    public Camera center;
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
            Camera c = (cameraManager.split) ? p1Cam : center;

            Vector2 mPos = c.ScreenToWorldPoint(Input.mousePosition);
            
            Vector2 dir = mPos - p1.Position;
            
            // Call p1's fire code.
            p1.Fire(dir);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Camera c = (cameraManager.split) ? p2Cam : center;

            Vector2 mPos = c.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mPos - p2.Position;
            
            // Call p2's fire code.
            p2.Fire(dir);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(p1Cam.ScreenToWorldPoint(Input.mousePosition), 0.25f);
    }
}
