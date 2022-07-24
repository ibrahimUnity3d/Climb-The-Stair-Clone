using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New UpgradeData", menuName = "ScriptableObjects / UpgradeData")]
public class UpgradeData : ScriptableObject
{
    [Header("Stamina")]
    public int appearingStaminaGrade;
    public float maximumStaminaValue;

    [Header("ResetBeforeBuild")]
    public int deadStaminaGradesCount;
    public int realStaminaGrade;

    [Space]

    [Header("Money")]
    public float currentMoney;
    public float incomeForOneStep;

    public int inComeGrade;

    public int staminaUpgradeCost;
    public int incomeUpgradeCost;
    public int speedUpgradeCost;

    [Space]

    [Header("Speed")]
    public int appearingSpeedGrade;
    public float currentSpeedValue;

    [Header("ResetBeforeBuild")]
    public int deadSpeedGradesCount;
    public int realSpeedGrade;
    
}
