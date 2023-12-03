using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    [SerializeField] FawnMovement fm;
    [SerializeField] PlayerMovement pm;
    [SerializeField] CharacterController2D cc;
    private bool deerMode = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) { 
            if(!deerMode)
            {
                SwitchToDeer();
            }
            else
            {
                SwitchToChild();
            }
        }
    }

    void SwitchToDeer()
    {
        pm.enabled = false;
        cc.enabled = false;
        fm.enabled = true;
        deerMode = true;
    }

    void SwitchToChild()
    {
        pm.enabled = true;
        cc.enabled = true;
        fm.enabled = false;
        deerMode = false;
    }
}
