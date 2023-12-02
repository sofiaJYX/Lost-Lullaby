using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseItems : MonoBehaviour
{
    [SerializeField] GameObject item;
    //[SerializeField] AudioClip clip;
    [SerializeField] GameObject itemInfo;
    bool shown = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && shown == false) //only display if player hasnt seen it already
        {
            //AudioSource.PlayClipAtPoint(clip, transform.position);
            Debug.Log("Contact with item");
            StartCoroutine(DisplayMessage(itemInfo));

        }
    }

    public IEnumerator DisplayMessage(GameObject itemInfo)
    {
        itemInfo.SetActive(true);
        yield return new WaitForSeconds(4);     //show for 4 seconds
        itemInfo.SetActive(false);
    }
}
