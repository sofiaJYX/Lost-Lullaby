using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.Unicode;

public class UIScriptLvl1 : MonoBehaviour
{
    [SerializeField] GameObject startMessage;
    [SerializeField] GameObject tip1;
    //[SerializeField] AudioClip tune;
    [SerializeField] GameObject MusicTextBox;
    [SerializeField] GameObject tip2;
    //[SerializeField] GameObject blackPanel;
    [SerializeField] HousePlayerMovement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startDialogue());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator startDialogue()
    {
        movementScript.enabled = false;
        yield return new WaitForSeconds(2);
        startMessage.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        startMessage.SetActive(false);
        movementScript.enabled = true;

        yield return new WaitForSeconds(1);
        tip1.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        tip1.SetActive(false);
    }


    public IEnumerator MusicBoxStart()
    {
        //AudioSource.PlayClipAtPoint(tune, transform.position);
        movementScript.enabled = false;
        yield return new WaitForSeconds(2);
        MusicTextBox.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));  //display until player presses E
        MusicTextBox.SetActive(false);
        movementScript.enabled = true;

        yield return new WaitForSeconds(1);

        tip2.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); //display until player presses E
        tip2.SetActive(false);
    }

    //public IEnumerator FadeToBlack(bool fadeToBlack = true, int fadeSpeed = 20)      
    ////method for animating a coloured panel fading in/out obtained from https://turbofuture.com/graphic-design-video/How-to-Fade-to-Black-in-Unity and modified for our purposes
    //{
    //    if (fadeToBlack) //fade colour in
    //    {
    //        Color objectColor = blackPanel.GetComponent<Image>().color;
    //        float fadeAmount;
    //        while (blackPanel.GetComponent<Image>().color.a < 1)
    //        {
    //            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
    //            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //            blackPanel.GetComponent<Image>().color = objectColor;
    //            yield return null;
    //        }
    //    }
    //    else //fade colour out
    //    {
    //        Color objectColor = blackPanel.GetComponent<Image>().color;
    //        float fadeAmount;
    //        while (blackPanel.GetComponent<Image>().color.a > 0)
    //        {
    //            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
    //            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //            blackPanel.GetComponent<Image>().color = objectColor;
    //            yield return null;
    //        }
    //    }
    //}
}
