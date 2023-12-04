using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction using both horizontal and vertical input
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Update the position of the camera
        transform.Translate(moveDirection, Space.Self);
    }
}
