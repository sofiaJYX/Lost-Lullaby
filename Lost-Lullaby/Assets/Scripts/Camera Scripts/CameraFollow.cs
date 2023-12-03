using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's Transform

    public float smoothSpeed = 0.125f; // The smoothness of camera movement

    public Vector3 offset; // The offset from the player

    void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Camera target not set!");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // You can add additional code to handle camera bounds if needed
        // For example: transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
