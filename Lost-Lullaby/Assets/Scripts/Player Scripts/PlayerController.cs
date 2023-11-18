using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //set fear to initially be 0
    public float fear;
    public FearController fearBar;
    // Start is called before the first frame update
    void Start()
    {
        fear = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //if our item is collected by a player
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Item was touched by Player");
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
        Debug.Log("Fear Decreased");
        //decrease 30 of the fear
        // fear -= 30f;

        fearBar.setFear(-30f);

        //Decrease 30% of the fear 
        //fear *= 0.3f;
    }
}
