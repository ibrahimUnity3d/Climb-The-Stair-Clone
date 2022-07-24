using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] bool CanClick = true;


    private void OnEnable()
    {
        EventManager.getFalseCanClick += GetFalseCanClick;
        EventManager.getTrueCanClick += GetTrueCanClick;
    }

    private void OnDisable()
    {
        EventManager.getFalseCanClick -= GetFalseCanClick;
        EventManager.getTrueCanClick -= GetTrueCanClick;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && CanClick)
        {
            EventManager.mouseClicked();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            EventManager.mouseButtonUp();
        }
    }


    void GetTrueCanClick()
    {
        CanClick = true;
    }

    void GetFalseCanClick()
    {
        CanClick = false;
    }

}
