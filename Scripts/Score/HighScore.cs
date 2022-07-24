using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] GameObject currentScoreObject;
    [SerializeField] GameData gamedata;
    [SerializeField] TextMeshPro highScoreText;
    CurrentScore currentScoreScript;


    private void OnEnable()
    {
        EventManager.winGame += CheckHighScore;
        EventManager.loseGame += CheckHighScore;
    }

    private void OnDisable()
    {
        EventManager.winGame -= CheckHighScore;
        EventManager.loseGame -= CheckHighScore;
    }



    private void Start()
    {
        currentScoreScript = currentScoreObject.GetComponent<CurrentScore>();
        transform.position = gamedata.highScorePosition;
        highScoreText.text = gamedata.highScore.ToString("F1");
    }



    //lose-win durumunda tetiklenecek
    public void CheckHighScore()
    {
        var currentScore = currentScoreScript.currentScore;
        if (currentScore >= gamedata.highScore)
        {
            gamedata.highScore = currentScore;

            var newPosition = currentScoreObject.transform.position;
            gamedata.highScorePosition = newPosition;
        }
    }
}
