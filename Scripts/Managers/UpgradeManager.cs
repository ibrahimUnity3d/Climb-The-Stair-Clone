using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] UpgradeData upgradeData;
    [SerializeField] GameObject player;
    PlayerAnimations playerAnimationsScript;
    PlayerMovement playerMovementScript;
    StaminaSystem staminaSystemScript;

    

    private void Start()
    {
        //TODO:build oncesi yorum satirina alinacak.
        //ResetUgrades();
        UpdateRealGrades();
        ScriptAssignment();
        UpdateSpeedValue();
        UpdateStaminaValue();
    }



    private void OnEnable()
    {
        EventManager.winGame += UpdateDeadGrades;
    }
    private void OnDisable()
    {
        EventManager.winGame -= UpdateDeadGrades;
    }


    #region Upgrades
    public void UpgradeStaminaGrade()
    {
        upgradeData.appearingStaminaGrade++;
        upgradeData.realStaminaGrade = upgradeData.appearingStaminaGrade - upgradeData.deadStaminaGradesCount;
        UpdateStaminaValue();
        print("upgradeted stamina" + upgradeData.maximumStaminaValue);

    }



    public void UpgradeIncomeGrade()
    {
        upgradeData.inComeGrade++;
        UpdateIncomeForOneStep();
    }


    public void UpgradeSpeedGrade()
    {
        upgradeData.appearingSpeedGrade++;
        upgradeData.realSpeedGrade = upgradeData.appearingSpeedGrade - upgradeData.deadSpeedGradesCount;
        UpdateSpeedValue();
        playerMovementScript.UpdateStepDuration();
        print("upgradeted speed" + upgradeData.currentSpeedValue);
    }
    #endregion




    //level bitimi olacak.
    private void UpdateRealGrades()
    {
        
        upgradeData.realSpeedGrade = upgradeData.appearingSpeedGrade - upgradeData.deadSpeedGradesCount;
        upgradeData.realStaminaGrade = upgradeData.appearingStaminaGrade - upgradeData.deadStaminaGradesCount;
    }

    void UpdateDeadGrades()
    {
        upgradeData.deadSpeedGradesCount = upgradeData.appearingSpeedGrade;
        upgradeData.deadStaminaGradesCount = upgradeData.appearingStaminaGrade;
    }


    void UpdateSpeedValue()
    {
        upgradeData.currentSpeedValue = 1 + (gameData.speedFactor * upgradeData.realSpeedGrade);
        playerAnimationsScript.UpdatePlayerSpeed();
    }

    void UpdateStaminaValue()
    {
        upgradeData.maximumStaminaValue = 100 + (gameData.staminaFactor * upgradeData.realStaminaGrade);
        staminaSystemScript.UpdateMaximumStaminaByGrade();
    }

    

    void UpdateIncomeForOneStep()
    {
        var incomeGrade = upgradeData.inComeGrade;

        if(incomeGrade<5)
        {
            upgradeData.incomeForOneStep += 0.2f;
        }
        else if(incomeGrade < 10)
        {
            upgradeData.incomeForOneStep += 0.3f;
        }

        else if(incomeGrade<20)
        {
            upgradeData.incomeForOneStep += 0.5f;
        }
        else
        {
            upgradeData.incomeForOneStep += 0.7f;
        }
    }


    void ResetUgrades()
    {
        upgradeData.inComeGrade = 0;

        upgradeData.deadSpeedGradesCount = 0;
        upgradeData.appearingSpeedGrade = 0;
        upgradeData.realSpeedGrade = 0;

        upgradeData.appearingStaminaGrade = 0;
        upgradeData.deadStaminaGradesCount = 0;
        upgradeData.realStaminaGrade = 0;

        upgradeData.currentMoney = 7000;
        upgradeData.incomeForOneStep = 0.2f;
        upgradeData.speedUpgradeCost = 30;
        upgradeData.staminaUpgradeCost = 40;
        upgradeData.incomeUpgradeCost = 50;
    }

    private void ScriptAssignment()
    {
        playerAnimationsScript = player.GetComponent<PlayerAnimations>();
        playerMovementScript = player.GetComponent<PlayerMovement>();
        staminaSystemScript = player.GetComponent<StaminaSystem>();
    }
}
