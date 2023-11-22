using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FawnMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Animator animator; // Reference to the deer's animator
    SpriteRenderer deerSprite; // Reference to the deer's SpriteRenderer component

    void Start()
    {
        deerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if the player is moving
        float playerSpeed = Mathf.Abs(player.GetComponent<PlayerMovement>().horizontalMovement);

        // Set the "isWalking" parameter in the animator based on the player's movement
        animator.SetBool("isWalking", playerSpeed > 0);

        // Flip the deer's sprite based on the player's movement direction
        if (playerSpeed > 0)
        {
            if (player.position.x > transform.position.x)
                deerSprite.flipX = false; // face right
            else
                deerSprite.flipX = true; // face left
        }
    }
}
