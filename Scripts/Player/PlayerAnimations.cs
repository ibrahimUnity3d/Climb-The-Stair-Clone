using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] UpgradeData upgradeData;
    Animator animator;
    bool isStatePlayState = false;




    private void OnEnable()
    {
        EventManager.mouseClicked += SetIsRunningTrue;
        EventManager.mouseButtonUp += SetIsRunningFalse;
        EventManager.playGame += SetPlayStateTrue;
        EventManager.loseGame += SetPlayStateFalse;
        EventManager.winGame += SetPlayStateFalse;

        animator = GetComponentInChildren<Animator>();

        animator.speed = 1;
    }


    private void OnDisable()
    {
        EventManager.mouseClicked -= SetIsRunningTrue;
        EventManager.mouseButtonUp -= SetIsRunningFalse;
        EventManager.playGame -= SetPlayStateTrue;
        EventManager.loseGame -= SetPlayStateFalse;
        EventManager.winGame -= SetPlayStateFalse;
    }




    public void UpdatePlayerSpeed()
    {
        animator.speed = upgradeData.currentSpeedValue;
    }


    void SetPlayStateTrue()
    {
        isStatePlayState = true;
    }

    void SetPlayStateFalse()
    {
        isStatePlayState = false;
        EventManager.mouseButtonUp();
    }






    //TODO: bool parametreli bi fonksiyona donusturulebilir.
    void SetIsRunningTrue()
    {
        if (!isStatePlayState)
            return;
        animator.SetBool("isRunning", true);
    }

    void SetIsRunningFalse()
    {
        animator.SetBool("isRunning", false);
    }


}
