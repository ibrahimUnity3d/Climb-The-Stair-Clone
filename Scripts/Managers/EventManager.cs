using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventManager 
{
    public static Action<Vector3, Quaternion> newStepTransform;
    public static Action<float> newStepPositionY;

    public static Action createAStep;


    #region control actions
    public static Action mouseClicked;
    public static Action mouseButtonUp;

    public static Action getFalseCanClick;
    public static Action getTrueCanClick;
    #endregion


    public static Action playGame;
    public static Action loseGame;
    public static Action winGame;


    public static Action updateMoneyText;
}
