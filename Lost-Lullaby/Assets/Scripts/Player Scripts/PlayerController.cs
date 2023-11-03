using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fear = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //if our sprite is collected by a player
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched");
        if (collision.tag == "collectibles")
        {
            //call collected
            DecreaseFear();
        }
        //method for music box and update UI
    }

    void DecreaseFear()
    {
        Debug.Log("Decreased");
        fear -= 30f;
    }
}
