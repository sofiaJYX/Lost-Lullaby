using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static Unity.Collections.Unicode;

public class UIScriptLvl1 : MonoBehaviour
{
    [SerializeField] GameObject startMessage;
    [SerializeField] GameObject tip1;
    [SerializeField] GameObject MusicTextBox;
    [SerializeField] GameObject tip2;
    [SerializeField] AudioClip tune;
    [SerializeField] HousePlayerMovement movementScript;
    [SerializeField] UniversalRenderPipelineAsset URP;
    //[SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
        GraphicsSettings.renderPipelineAsset = URP;
        //cam.transparencySortMode = TransparencySortMode.CustomAxis;
        StartCoroutine(StartDialogue());
    }

    private IEnumerator StartDialogue()
    {
        movementScript.enabled = false;
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(ShowMessage(startMessage));

        yield return new WaitForSeconds(1);
        yield return StartCoroutine(ShowMessage(tip1));
    }


    public IEnumerator MusicBoxStart()
    {
        AudioSource.PlayClipAtPoint(tune, transform.position);
        movementScript.enabled = false;
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(ShowMessage(MusicTextBox));

        yield return new WaitForSeconds(1);
        yield return StartCoroutine(ShowMessage(tip2));
    }

    public IEnumerator ShowMessage(GameObject obj)
    {
        movementScript.enabled = false; 
        obj.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));  //display until player presses E
        obj.SetActive(false);
        movementScript.enabled = true;
    }
}
