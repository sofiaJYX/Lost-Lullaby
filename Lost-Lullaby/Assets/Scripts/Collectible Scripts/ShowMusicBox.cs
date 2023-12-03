using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMusicBox : MonoBehaviour
{
    public GameObject musicBox; // Reference to the GameObject you want to control visibility

    // Reference to the script with the counter variable
    public PlayerController playerController;

    void Update()
    {
        if (playerController == null)
        {
            Debug.LogError("Counter script not assigned!");
            return;
        }

        int musicBoxPieces = playerController.musicBoxPieces; // Assuming 'counter' is the variable in CounterScript

        //Make sure the music box isn't null
        if(musicBox != null)
        {
            //See if all the pieces have been collected
            if (musicBoxPieces >= 4)
            {
                // Activate the object (make it visible)
                musicBox.SetActive(true);
            }
            else
            {
                // Deactivate the object (make it invisible)
                musicBox.SetActive(false);
            }
        }
    }
}
