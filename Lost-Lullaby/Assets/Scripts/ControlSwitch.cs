using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    [SerializeField] FawnMovement fm;
    [SerializeField] FawnController fcc;
    [SerializeField] PlayerMovement pm;
    [SerializeField] CharacterController2D pcc;
    private bool deerMode = false;

    // Start is called before the first frame update
    void Start()
    {
        fm.enabled = false;
        fcc.enabled = false;
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
        pcc.enabled = false;
        fm.enabled = true;
        fcc.enabled = true;
        deerMode = true;
    }

    void SwitchToChild()
    {
        pm.enabled = true;
        pcc.enabled = true;
        fm.enabled = false;
        fcc.enabled = false;
        deerMode = false;
    }
}
