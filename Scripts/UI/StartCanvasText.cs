using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartCanvasText : MonoBehaviour
{
    [SerializeField] LevelData levelData;
    [SerializeField] UpgradeData upgradeData;
    [SerializeField] GameObject staminaGradeObject, staminaCostObject;
    [SerializeField] GameObject incomeGradeObject, incomeCostObject;
    [SerializeField] GameObject speedGradeObject, speedCostObject;

    TextMeshProUGUI staminaGradeText, staminaCostText;
    TextMeshProUGUI incomeGradeText, incomeCostText;
    TextMeshProUGUI speedGradeText, speedCostText;




    private void Start()
    {
        AssignTextComponents();
        UpdateStaminaButtonTexts();
        UpdateIncomeButtonTexts();
        UpdateSpeedButtonTexts();
    }


    public void UpdateStaminaButtonTexts()
    {
        string  level = "Lvl " + upgradeData.appearingStaminaGrade.ToString();
        staminaGradeText.text = level;

        staminaCostText.text = upgradeData.staminaUpgradeCost.ToString();
    }


    public void UpdateIncomeButtonTexts()
    {
        string level = "Lvl " + upgradeData.inComeGrade.ToString();
        incomeGradeText.text = level;

        incomeCostText.text = upgradeData.incomeUpgradeCost.ToString();
    }

    public void UpdateSpeedButtonTexts()
    {
        string level = "Lvl " + upgradeData.appearingSpeedGrade.ToString();
        speedGradeText.text = level;

        speedCostText.text = upgradeData.speedUpgradeCost.ToString();
    }


    void AssignTextComponents()
    {
        staminaGradeText = staminaGradeObject.GetComponent<TextMeshProUGUI>();
        staminaCostText = staminaCostObject.GetComponent<TextMeshProUGUI>();

        incomeGradeText = incomeGradeObject.GetComponent<TextMeshProUGUI>();
        incomeCostText = incomeCostObject.GetComponent<TextMeshProUGUI>();

        speedGradeText = speedGradeObject.GetComponent<TextMeshProUGUI>();
        speedCostText = speedCostObject.GetComponent<TextMeshProUGUI>();
    }
}
