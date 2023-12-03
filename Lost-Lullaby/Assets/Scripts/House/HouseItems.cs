using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HouseItems : MonoBehaviour
{
    [SerializeField] GameObject item;
    //[SerializeField] AudioClip clip;
    [SerializeField] GameObject itemInfo;
    bool shown = false;
    static int itemCount = 0;
    const int MAX_ITEMS = 13;
    [SerializeField] Text itemCounter; 
    [SerializeField] Text itemCounterShadow;
    static bool showingMessage = false;

    [SerializeField] UIScriptLvl1 uiScript;
    [SerializeField] GameObject musicBox;
    //[SerializeField] AudioClip tune;
    [SerializeField] GameObject darkPanel;
    [SerializeField] HousePlayerMovement movementScript;

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
            if (itemCount < MAX_ITEMS)
            {
                StartCoroutine(DisplayInfo(itemInfo));
            }
            else    //when player finds music box
            {
                //idk animate and play music again
                MusicBoxFound();
            }
        }
    }

    public IEnumerator DisplayInfo(GameObject itemInfo)
    {
        showingMessage = true;
        itemCount++;
        itemCounter.text = itemCount.ToString();
        itemCounterShadow.text = itemCount.ToString();
        itemInfo.SetActive(true);
        movementScript.enabled = false;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));   //show until player presses E
        itemInfo.SetActive(false);
        movementScript.enabled = true;
        showingMessage = false;

        if (itemCount == MAX_ITEMS)  //if all items collected, start music box tune/events
        {
            StartCoroutine(uiScript.MusicBoxStart());
            musicBox.SetActive(true);
        }
    }

    void MusicBoxFound()
    {
        itemInfo.SetActive(true);
        movementScript.enabled = false;
        //StartCoroutine(uiScript.FadeToBlack());
    }
}
