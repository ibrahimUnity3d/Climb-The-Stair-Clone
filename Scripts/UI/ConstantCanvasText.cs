using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConstantCanvasText : MonoBehaviour
{
    [SerializeField] LevelData levelData;
    [SerializeField] UpgradeData upgradeData;
    [SerializeField] GameObject sliderObject, levelTextObject, moneyTextObject;

    Image sliderImage;
    TextMeshProUGUI levelText;
    TextMeshProUGUI moneyText;
    float sliderDivident, sliderDivisor;



    private void OnEnable()
    {
        EventManager.updateMoneyText += UpdateMoneyText;
    }

    private void OnDisable()
    {
        EventManager.updateMoneyText -= UpdateMoneyText;
    }



    // Start is called before the first frame update
    void Start()
    {
        sliderImage = sliderObject.GetComponent<Image>();

        levelText = levelTextObject.GetComponent<TextMeshProUGUI>();
        moneyText = moneyTextObject.GetComponent<TextMeshProUGUI>();

        sliderDivident = (levelData.levelCount - levelData.currentLevel + 1)*100;

        UpdateLevelText();
        UpdateMoneyText();
    }



    private void UpdateLevelText()
    {
        var levelString = "Level " + levelData.currentLevel.ToString();
        levelText.text = levelString;
    }
    


   public void UpdateSlider(float currentScore)
    {
        sliderImage.fillAmount = (sliderDivident + currentScore) / sliderDivident;
    }




    void UpdateMoneyText()
    {
        var stringMoney = upgradeData.currentMoney.ToString("F1");
        moneyText.text = stringMoney;
    }
}
