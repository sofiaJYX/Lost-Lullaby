using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsRoom : MonoBehaviour
{
    [SerializeField] GameObject message;
    [SerializeField] HousePlayerMovement movementScript;
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            message.SetActive(true);
            movementScript.enabled = false;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));   //show until player presses E
            message.SetActive(false);
            movementScript.enabled = true;
        }
    }
}
