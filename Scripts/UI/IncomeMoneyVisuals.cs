using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class IncomeMoneyVisuals : MonoBehaviour
{
    [SerializeField] GameObject moneyPrefab;
    [SerializeField] UpgradeData upgradeData;
    float durationFactor;


    private void OnEnable()
    {
        EventManager.newStepTransform += CreateMoneyVisual;
    }

    private void OnDisable()
    {
        EventManager.newStepTransform -= CreateMoneyVisual;
    }

    private void Start()
    {
        UpdateDurationFactor();
    }

    void UpdateDurationFactor()
    {
        durationFactor = 1 / upgradeData.currentSpeedValue;
    }


    void CreateMoneyVisual(Vector3 newStepPosition, Quaternion rotation)
    {
        transform.position = newStepPosition;
        var newMoney = Instantiate(moneyPrefab, this.transform);
        newMoney.GetComponent<TextMeshPro>().text = upgradeData.incomeForOneStep.ToString("F1");
        
        newMoney.transform.DOScale(.75f, 0.75f * durationFactor);
        newMoney.transform.DOMove(newStepPosition, 0.5f * durationFactor).SetEase(Ease.InCubic);
        Destroy(newMoney, .85f * durationFactor);
    }
}
