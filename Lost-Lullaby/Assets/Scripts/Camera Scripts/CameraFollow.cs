using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // The player's Transform
    public Transform fawn; // The fawn's transform

    public Transform target;

    private bool fawnCam = false;

    public float smoothSpeed = 0.125f; // The smoothness of camera movement

    public Vector3 offset; // The offset from the player

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            fawnCam = !fawnCam;
        }
    }

    void FixedUpdate()
    {
        if (player == null || fawn == null)
        {
            Debug.LogError("Camera target not set!");
            return;
        }

        if (fawnCam)
        {
            target = fawn;
        } else
        {
            target = player;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
