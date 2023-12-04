using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    Vector2 movement;


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.magnitude);

        //If the input is moving the player right and the player is facing left...
        if (movement.x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    //Method to flip the player to face Left/Right
    private void Flip()
    {
        //Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        //Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
