using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FearController : MonoBehaviour
{
    public PlayerController player;

    private string currentSceneName = SceneManager.GetActiveScene().name;

    //fear bar image
    public Image fearBarFill;
    //max fear
    private const float MAX_FEAR = 100f;
    //fear of player
    public float fear;
    //how much we gain fear
    public float fearIncRate = 3f;
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
    }

    public void setFear(float amount)
    {
        fear += amount;
    }
}

