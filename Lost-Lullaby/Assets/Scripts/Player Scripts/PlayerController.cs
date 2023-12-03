using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //set fear to initially be 0
    public float fear;
    public FearController fearBar;
    public float playerVoidLevel;

    private string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName.Equals("CaveScene"))
        {
            playerVoidLevel = -14.0f;
        }

        fear = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= playerVoidLevel || fear >= 100.0)
        {
            SceneManager.LoadScene(currentSceneName);
        }
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
