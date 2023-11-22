using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    //Location of the tracked object
    public Transform trackedObject;

    //Speed at which the camera updates
    public float updateSpeed = 5;

    public Vector2 trackingOffset;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - trackedObject.position.z;
        offset.y = trackedObject.position.y + 3;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + offset, updateSpeed * Time.deltaTime);
    }
}
