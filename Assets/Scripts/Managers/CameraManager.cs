using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Players")]
    public Player p1;
    public Player p2;

    [Header("Cameras")]
    public Camera spCam1;
    public Camera spCam2;
    public Camera centerCam;

    [Header("Split Settings")]
    public float zOffset = -10f;
    public float splitDistance = 20f;

    private Bounds b;

    // Update is called once per frame
    void Update()
    {
        // Move the two follow cams to the players positions.
        spCam1.transform.position = p1.Position;
        spCam2.transform.position = p2.Position;

        spCam1.transform.position += new Vector3(0, 0, zOffset);
        spCam2.transform.position += new Vector3(0, 0, zOffset);

        // Create the bounds around the players.
        b = new Bounds();
        b.Encapsulate(p1.Position);
        b.Encapsulate(p2.Position);

        // Move the center camera to the center.
        centerCam.transform.position = b.center + new Vector3(0, 0, zOffset);

        // Enable/Disable based off the split distance.
        if(Vector2.Distance(p1.Position,p2.Position) < splitDistance)
        {
            // Center cam is enabled, and split cams are disabled.
            spCam1.enabled = false;
            spCam2.enabled = false;
            centerCam.enabled = true;
        } else
        {
            // Center cam is disabled, and split cams are enabled.
            spCam1.enabled = true;
            spCam2.enabled = true;
            centerCam.enabled = false;
        }
    }
}
