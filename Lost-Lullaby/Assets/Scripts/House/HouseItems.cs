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
    static int itemCount = 0;
    [SerializeField] Text itemCounter; 
    [SerializeField] Text itemCounterShadow;
    static bool showingMessage = false;

    private void Start()
    {
        itemCounter.text = itemCount.ToString();
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && shown == false) //only display if player hasnt seen it already
        {
            //AudioSource.PlayClipAtPoint(clip, transform.position);
            Debug.Log("Contact with item");
            shown = true;
            yield return new WaitUntil(() => !showingMessage);
            StartCoroutine(DisplayMessage(itemInfo));
        }
    }

    public IEnumerator DisplayMessage(GameObject itemInfo)
    {
        showingMessage = true;
        itemCount++;
        itemCounter.text = itemCount.ToString();
        itemCounterShadow.text = itemCount.ToString();
        itemInfo.SetActive(true);
        yield return new WaitForSeconds(4);     //show for 4 seconds
        itemInfo.SetActive(false);
        showingMessage = false;
    }
}
