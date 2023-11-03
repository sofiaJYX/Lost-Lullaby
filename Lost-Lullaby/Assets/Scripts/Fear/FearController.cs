using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearController : MonoBehaviour
{
    public PlayerController player;

    private Image fearBarFill;
    private const float MAX_FEAR = 100f;
    public float fear;
    public float fearIncRate = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        fearBarFill = GetComponent<Image>();
        fear = player.fear;
        fearBarFill.fillAmount = fear;
    }

    // Update is called once per frame
    void Update()
    {
        fear += fearIncRate * Time.deltaTime;
        fear = Mathf.Min(fear, MAX_FEAR);
        fearBarFill.fillAmount = fear / MAX_FEAR;
    }

}
