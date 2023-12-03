using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //get reference to character controller
    public CharacterController2D controller;
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
        jump = true;
        animator.SetBool("isJumping", jump);
    }

    if (Input.GetButtonDown("Crouch"))
    {
        crouch = true;
    }
    else if (Input.GetButtonUp("Crouch"))
    {
        crouch = false;
    }
}

    void FixedUpdate()
    {
        //move our player (apply input) - and hand in our crouch and jump variable
        //we used fixedDeltaTime to ensure we move the same amount no matter how many times the function has been called
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        //stop jumping
        jump = false;
    }

    //stop jumping when we land
    public void OnLanding()
    {
        //give our animators variable isJumping the value of jump
        animator.SetBool("isJumping", false);
    }
}
