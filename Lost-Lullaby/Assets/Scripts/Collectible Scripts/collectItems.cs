using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectItems : MonoBehaviour
{
    //sprite
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //get our sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        //fear = fearBar.fear;
    }

    void Update()
    {
       
    }


    //if our sprite is collected by a player
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            //call collected
            Collected();
        }
    }

    //remove sprite from scene and decrease fear
    void Collected()
    {
        spriteRenderer.enabled = false;
        //delete entirely
    }

}
