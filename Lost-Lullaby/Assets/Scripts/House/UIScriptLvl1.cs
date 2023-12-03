using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.Unicode;

public class UIScriptLvl1 : MonoBehaviour
{
    [SerializeField] GameObject startMessage;
    [SerializeField] GameObject tip1;
    [SerializeField] GameObject MusicTextBox;
    [SerializeField] GameObject tip2;
    //[SerializeField] AudioClip tune;
    [SerializeField] HousePlayerMovement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startDialogue());
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
}
