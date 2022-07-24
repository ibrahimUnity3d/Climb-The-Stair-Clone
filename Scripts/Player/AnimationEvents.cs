using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class AnimationEvents : MonoBehaviour
{
    PlayerMovement movementScript;
    

    // Start is called before the first frame update
    void Start()
    {
        movementScript = transform.parent.GetComponent<PlayerMovement>();
    }


    void UpdateYPos()
    {
        movementScript.MoveToPosionY();
    }

    //TODO: bool parametreli methoda donusturulebilir.
    void GetFalseCanClick()
    {
        EventManager.getFalseCanClick();
    }
    void GetTrueCanClick()
    {
        EventManager.getTrueCanClick();
    }

    void CreateStep()
    {
        EventManager.createAStep();
    }
}
