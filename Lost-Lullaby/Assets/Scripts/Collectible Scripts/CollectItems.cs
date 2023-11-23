using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    //our game object to destroy
    [SerializeField]
    GameObject item;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //when we collide with a player...
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {

            AudioSource.PlayClipAtPoint(clip, transform.position);
            //... We want to remove the entire object from scene
            Debug.Log("Destroyed item");
            Destroy(item);
        }
    }

    //Method to destroy object
    public void DestroyGameObject()
    {
        Destroy(item);
    }
}
