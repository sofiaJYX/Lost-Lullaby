using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //get reference to character controller
    public CharacterController2D controller;
    //how much we move horizontally
    float horizontalMovement = 0f;
    //are we jumping?
    bool jump = false;
    //are we crouching?
    bool crouch = false;
    //player run speed
    public float runSpeed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from player to move Left and Right
        horizontalMovement = Input.GetAxisRaw("Horizontal")*runSpeed;

        //if we pressed space to jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //if we pressed space left ctrl to crouch
        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("Crouching");
            crouch = true;
        }
        //We use an else if to make the player HOLD Left CTRL to crouch
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
}