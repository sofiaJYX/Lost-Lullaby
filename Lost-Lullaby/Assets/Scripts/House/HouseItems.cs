using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseItems : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] AudioClip clip;

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
}
