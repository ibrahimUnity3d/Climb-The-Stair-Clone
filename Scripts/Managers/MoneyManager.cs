using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] GameObject ButtonControllerObject;
    [SerializeField] GameObject upgradeManagerObject;
    [SerializeField] GameObject startCanvas;

    StartCanvasText startCanvasTextScript;
    ButtonController buttonControllerScript;
    UpgradeManager upgradeManagerScript;


    //TODO: currentmoneyupgrade datadan cikarilacak.
    [SerializeField] UpgradeData upgradeData;

    float staminaCostMultiplier = 1.2f, incomeCostMultiplier = 1.3f,
        speedCostMultiplier = 1.25f;



    private void OnEnable()
    {
        EventManager.createAStep += RaiseCurrentMoney;
    }

    private void OnDisable()
    {
        EventManager.createAStep -= RaiseCurrentMoney;
    }

    private void Start()
    {
        buttonControllerScript = ButtonControllerObject.GetComponent<ButtonController>();
        upgradeManagerScript = upgradeManagerObject.GetComponent<UpgradeManager>();
        startCanvasTextScript = startCanvas.GetComponent<StartCanvasText>();
        CheckAbilityToUpgrades();
    }



    void RaiseCurrentMoney()
    {
        upgradeData.currentMoney += upgradeData.incomeForOneStep;
        EventManager.updateMoneyText();
    }


    void CheckAbilityToUpgrades()
    {
        var currentMoney = upgradeData.currentMoney;

        bool canPressStamina = currentMoney >= upgradeData.staminaUpgradeCost;
        bool canPressIncome = currentMoney >= upgradeData.incomeUpgradeCost;
        bool canPressSpeed = currentMoney >= upgradeData.speedUpgradeCost;

        buttonControllerScript.UpdateCanPressButtonBools(canPressStamina, canPressIncome, canPressSpeed);
    }


    public void SpendStaminaUpgradeCost()
    {
        upgradeData.currentMoney -= upgradeData.staminaUpgradeCost;

        EventManager.updateMoneyText();

        //upgrade cost u guncelledik.
        upgradeData.staminaUpgradeCost = GetNewStaminaUpgradeCost();
        startCanvasTextScript.UpdateStaminaButtonTexts();

        CheckAbilityToUpgrades();
    }


    public void SpendIncomeUpgradeCost()
    {
        upgradeData.currentMoney -= upgradeData.incomeUpgradeCost;
        EventManager.updateMoneyText(); 

        //upgrade cost u guncelledik.
        upgradeData.incomeUpgradeCost = GetNewIncomeUpgradeCost();
        startCanvasTextScript.UpdateIncomeButtonTexts();

        CheckAbilityToUpgrades();
    }


    public void SpendSpeedUpgradeCost()
    {
        upgradeData.currentMoney -= upgradeData.speedUpgradeCost;
        EventManager.updateMoneyText();

        //upgrade cost u guncelledik.
        upgradeData.speedUpgradeCost = GetNewSpeedUpgradeCost();
        startCanvasTextScript.UpdateSpeedButtonTexts();

        CheckAbilityToUpgrades();
    }

    


    #region GetUpgradeCosts
    int GetNewSpeedUpgradeCost()
    {
        return Mathf.RoundToInt(upgradeData.speedUpgradeCost * speedCostMultiplier);
    }

    int GetNewIncomeUpgradeCost()
    {
        return Mathf.RoundToInt(upgradeData.incomeUpgradeCost * incomeCostMultiplier);
    }

    int GetNewStaminaUpgradeCost()
    {
        return Mathf.RoundToInt(upgradeData.staminaUpgradeCost * staminaCostMultiplier);
    }
    #endregion

}
