using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HouseItems : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject itemInfo;
    bool shown = false;
    static int itemCount = 0;
    const int MAX_ITEMS = 13;
    [SerializeField] Text itemCounter;
    [SerializeField] Text itemCounterShadow;
    [SerializeField] GameObject itemCounterObject;
    static bool showingMessage = false;

    [SerializeField] UIScriptLvl1 uiScript;
    [SerializeField] GameObject musicBox;
    [SerializeField] AudioClip tune;
    [SerializeField] HousePlayerMovement movementScript;
    [SerializeField] GameObject lightFlash;

    private void Start()
    {
        itemCounter.text = itemCount.ToString();
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && shown == false) //only display if player hasnt seen it already
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Debug.Log("Contact with item");
            shown = true;
            yield return new WaitUntil(() => !showingMessage);
            if (itemCount < MAX_ITEMS)
            {
                StartCoroutine(DisplayInfo(itemInfo));
            }
            else    //when player finds music box
            {
                StartCoroutine(MusicBoxFound());
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
            itemCounterObject.SetActive(false);
            StartCoroutine(uiScript.MusicBoxStart());
            musicBox.SetActive(true);
        }
    }

    IEnumerator MusicBoxFound() //animate and play music
    {
        itemInfo.SetActive(true);
        movementScript.enabled = false;
        AudioSource.PlayClipAtPoint(tune, transform.position);
        yield return new WaitForSeconds(5);
        StartCoroutine(Flash(2));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Flash(int times)
    {
        for (int i = 0; i < times; i++)
        {
            lightFlash.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            lightFlash.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
