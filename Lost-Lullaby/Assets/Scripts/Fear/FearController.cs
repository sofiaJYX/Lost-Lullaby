using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FearController : MonoBehaviour
{
    public PlayerController player;

    //fear bar image
    public Image fearBarFill;
    //max fear
    private const float MAX_FEAR = 100f;
    //fear of player
    public float fear;
    //how much we gain fear
    public float fearIncRate = 1f;

    //Controls the light radius around the player
    public GameObject lightCircle;
    // Light radius parameters
    public float minLightRadius = 0f;
    public float maxLightRadius = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //set our fearbar fill to be the spooky image
        fearBarFill = GetComponent<Image>();
        //our fear is equal to players fear
        fear = player.fear;
    }

    // Update is called once per frame
    void Update()
    {
        
        //update fear to increase slowly
        fear += fearIncRate * Time.deltaTime;
        //make sure fear does not exceed 100
        fear = Mathf.Min(fear, MAX_FEAR);
        //update fill amount of UI
        fearBarFill.fillAmount = fear / MAX_FEAR;

        // Adjust the light radius
        float normalizedFear = fear / MAX_FEAR;
        float newRadius = Mathf.Lerp(maxLightRadius, minLightRadius, normalizedFear);
        lightCircle.transform.localScale = new Vector3(newRadius, newRadius, lightCircle.transform.localScale.z);
    }

    public void setFear(float amount)
    {
        fear += amount;
    }
}

