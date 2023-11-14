using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //set fear to initially be 0
    public float fear = 0f;
    //TESTING
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //TESTING
        // Get horizontal input (left/right arrow keys or A/D keys).
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector.
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Update the player's position.
        transform.Translate(movement);
    }
    //if our item is collected by a player
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched");
        if (collision.tag == "Collectible")
        {
            //call collected
            DecreaseFear();
        }
        //method for music box and update UI
    }

    //decrease fear for collected item
    void DecreaseFear()
    {
        Debug.Log("Decreased");
        fear -= 30f;
    }
}
