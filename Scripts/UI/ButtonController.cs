using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject moneyManagerObject;
    [SerializeField] GameObject UpgradeManagerObject;
    [SerializeField] GameObject adStamina, adIncome, adSpeed, errorInternet;

    MoneyManager moneyManagerScript;
    UpgradeManager upgradeManagerScript;

    public bool canPressStaminaButton;
    public bool canPressIncomeButton;
    public bool canPressSpeedButton;

    private void Start()
    {
        moneyManagerScript = moneyManagerObject.GetComponent<MoneyManager>();
        upgradeManagerScript = UpgradeManagerObject.GetComponent<UpgradeManager>();
    }

    public void UpdateCanPressButtonBools(bool canPressStamina, bool canPressIncome, bool canPressSpeed)
    {
        canPressStaminaButton = canPressStamina;
        adStamina.SetActive(!canPressStamina);

        canPressIncomeButton = canPressIncome;
        adIncome.SetActive(!canPressIncome);

        canPressSpeedButton = canPressSpeed;
        adSpeed.SetActive(!canPressSpeed);
    }



   

    #region upgrade buttons pressed
    public void StaminaButtonPressed()
    {
        if (!canPressStaminaButton)
        {
            ActivateConnectionError();
            return;
        }
           
        upgradeManagerScript.UpgradeStaminaGrade();
        moneyManagerScript.SpendStaminaUpgradeCost();
    }


    public void IncomeButtonPressed()
    {
        if (!canPressIncomeButton)
        {
            ActivateConnectionError();
            return;
        }

        upgradeManagerScript.UpgradeIncomeGrade();
        moneyManagerScript.SpendIncomeUpgradeCost();
    }

   

    public void SpeedButtonPressed()  
    {
        if (!canPressSpeedButton)
        {
            ActivateConnectionError();
            return;
        }

        upgradeManagerScript.UpgradeSpeedGrade();
        moneyManagerScript.SpendSpeedUpgradeCost();
    }
    #endregion


    public void PlayGame()
    {
        EventManager.playGame();
    }



    public void ActivateConnectionError()
    {
        errorInternet.SetActive(true);
    }


    public void CloseErrorInternet()
    {
        errorInternet.SetActive(false);
    }
}
