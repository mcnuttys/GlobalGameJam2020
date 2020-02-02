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

    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set the keyboard players input.
        p1.SetDirection(new Vector2(Input.GetAxis("KeyboardHorizontal"), Input.GetAxis("KeyboardVertical")));

        // set the controller players input. (since no input just follow the other player.
        p2.SetDirection(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

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
        if (Input.GetAxis("Joy2Fire") != 0)
        {
            // Call p2's fire code.
            p2.Fire(new Vector2(Input.GetAxis("Joy2Horizontal"), Input.GetAxis("Joy2Vertical")));
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(p2.Position + new Vector2(Input.GetAxis("Joy2Horizontal"), Input.GetAxis("Joy2Vertical")), 0.25f);
    }
}
