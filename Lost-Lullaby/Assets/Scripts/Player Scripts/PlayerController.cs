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
        
    }
    //if our item is collected by a player
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched by Player");
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
