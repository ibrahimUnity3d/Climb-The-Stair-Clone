using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    [Header("designer")]
    [SerializeField] float staminaDecreaseAmount;
    [SerializeField] float staminaRecoveryAmount;
    [SerializeField] float rawStaminaDecreaseRate;

    [Header("izlenecekler")]

    [SerializeField] float staminaRate;
    [SerializeField] float currentStaminaValue;

    [Header("Others")]

    [SerializeField] UpgradeData upgradeData;
    [SerializeField] GameObject MeshObject;
    [SerializeField] GameObject playerModel, sweatParticleObject, deadParticleObject;
    [SerializeField] float maximumStamina;
    ColorLerp colorLerp;

    bool isStaminaUsable = false, isPlayerDead = false;
    float staminaDecreaseRate;

    //Not: her basamakta maximum staminayý ve current staminayo orantýsal olarak düþürüyoruz.

    #region OnEnableDisable
    private void OnEnable()
    {
        EventManager.createAStep += DecreaseStaminaCapacity;
        EventManager.playGame += MakeStaminaUsable;
        EventManager.winGame += MakeStaminaNotUsable;
    }

    private void OnDisable()
    {
        EventManager.createAStep -= DecreaseStaminaCapacity;
        EventManager.playGame -= MakeStaminaUsable;
        EventManager.winGame -= MakeStaminaNotUsable;
    }
    #endregion


    private void Start()
    {
        isStaminaUsable = false;
        staminaDecreaseRate = (100 - rawStaminaDecreaseRate) / 100; ;
        UpdateMaximumStaminaByGrade();
        colorLerp = playerModel.GetComponent<ColorLerp>();
    }



    // Update is called once per frame
    void Update()
    {
        FillAmount();

        if(staminaRate < 0.8f && !isPlayerDead)
        {
            sweatParticleObject.SetActive(true);
        }
       
        else
        {
            sweatParticleObject.SetActive(false);
        }


        //kosarken
        if (Input.GetMouseButton(0))
        {
            if (currentStaminaValue > 0 && isStaminaUsable)
            {
                if (isPlayerDead)
                    return;
                currentStaminaValue -= staminaDecreaseAmount * Time.deltaTime;
            }

            //lose.
            else if (isStaminaUsable)
            {
                isPlayerDead = true;
                MeshObject.SetActive(false);
                sweatParticleObject.SetActive(false);
                deadParticleObject.SetActive(true);
                EventManager.loseGame();
                MakeStaminaNotUsable();
            }
        }

        //dinlenme
        else
        {
            if (isPlayerDead)
                return;

            if (currentStaminaValue >= maximumStamina)
            {
                currentStaminaValue = maximumStamina;
            }
            else
            {
                currentStaminaValue += staminaRecoveryAmount * Time.deltaTime;
            }
        }
    }



    void MakeStaminaUsable()
    {
        isStaminaUsable = true;
    }

    void MakeStaminaNotUsable()
    {
        isStaminaUsable = false;
    }

    public void UpdateMaximumStaminaByGrade()
    {
        maximumStamina = upgradeData.maximumStaminaValue;
    }


    public void DecreaseStaminaCapacity()
    {
        maximumStamina *= staminaDecreaseRate;
        currentStaminaValue *= staminaDecreaseRate;
    }


    void FillAmount()
    {
        staminaRate = currentStaminaValue / maximumStamina;

        var fillAmount = staminaRate * 0.065f;

        colorLerp.LerpTo = fillAmount;
    }
}
