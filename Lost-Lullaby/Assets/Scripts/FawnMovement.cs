using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FawnMovement : MonoBehaviour
{

    //get reference to character controller
    public FawnController controller;
    //how much we move horizontally
    public float horizontalMovement = 0f;
    //are we jumping?
    bool jump = false;
    //are we crouching?
    bool crouch = false;
    //player run speed
    public float runSpeed = 25f;
    //access our animator by reference
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));

        // Update isWalking parameter based on movement
        bool isWalking = Mathf.Abs(horizontalMovement) > 0.1f; // Adjust the threshold as needed

        animator.SetBool("isWalking", isWalking);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Fawn Jump Movement");
            jump = true;
            //animator.SetBool("isJumping", jump);
        }
    }

    void FixedUpdate()
    {
        //move our player (apply input) - and hand in our crouch and jump variable
        //we used fixedDeltaTime to ensure we move the same amount no matter how many times the function has been called
        controller.Move(horizontalMovement * Time.fixedDeltaTime, jump);
        //stop jumping
        jump = false;
    }

    //stop jumping when we land
    public void OnLanding()
    {
        //give our animators variable isJumping the value of jump
        animator.SetBool("isJumping", false);
    }




    //public Transform player; // Reference to the player's transform
    //public Animator animator; // Reference to the deer's animator
    //SpriteRenderer deerSprite; // Reference to the deer's SpriteRenderer component

    //void Start()
    //{
    //    deerSprite = GetComponent<SpriteRenderer>();
    //}

    //void Update()
    //{
    //    // Check if the player is moving
    //    float playerSpeed = Mathf.Abs(player.GetComponent<PlayerMovement>().horizontalMovement);

    //    // Set the "isWalking" parameter in the animator based on the player's movement
    //    //animator.SetBool("isWalking", playerSpeed > 0);

    //    //Flip the deer's sprite based on the player's movement direction
    //    if (playerSpeed > 0)
    //    {
    //        if (player.position.x > transform.position.x)
    //            deerSprite.flipX = false; // face right
    //        else
    //            deerSprite.flipX = true; // face left
    //    }
    //}
}
