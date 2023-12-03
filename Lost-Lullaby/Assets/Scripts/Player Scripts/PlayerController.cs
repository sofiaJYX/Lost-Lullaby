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

    //Counter for music box pieces
    public int musicBoxPieces = 0;

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
        if(transform.position.y <= playerVoidLevel)
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
        if(collision.tag == "BoxPiece")
        {
            musicBoxPieces++;
            Debug.Log("Music Box Pieces: " + musicBoxPieces);
        }

        if(collision.tag == "MusicBox")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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
