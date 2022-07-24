using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    [HideInInspector] public float currentScore = -400f;
    [SerializeField] GameData gameData;
    [SerializeField] LevelData levelData;
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] GameObject constantCanvas;
    [SerializeField] Transform pole;
    ConstantCanvasText constantCanvasTextScript;
    float startScore;



    private void OnEnable()
    {
        EventManager.newStepPositionY += UpdateScoreBoardPosition;
    }

    private void OnDisable()
    {
        EventManager.newStepPositionY -= UpdateScoreBoardPosition;
    }

    private void Start()
    {
        startScore = -500f + levelData.currentLevel * 100;

        //TODOBUÝLD yorum satirindan cikarilacak.
        gameData.finishScore = startScore + 100f;
        currentScore = startScore;
        scoreText.text = startScore.ToString("F1");
        constantCanvasTextScript = constantCanvas.GetComponent<ConstantCanvasText>();
    }

    void UpdateScoreBoardPosition(float positionY)
    {
        var newPosition = new Vector3(transform.position.x, positionY, transform.position.z);

        pole.localScale = Vector3.zero;
        transform.position = newPosition;
        pole.DOScale(1, 0.3f);

        UpdateCurrentScore();
    }

    private void UpdateCurrentScore()
    {
        currentScore += 0.4f;
        scoreText.text = currentScore.ToString("F1");
        constantCanvasTextScript.UpdateSlider(currentScore);

        if (currentScore >= gameData.finishScore)
        {
            EventManager.winGame();
        }
    }
}
