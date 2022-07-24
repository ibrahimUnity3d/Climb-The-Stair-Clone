using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] LevelData levelData;
    [SerializeField] GameObject gameFinishedText,nextButton;

    private void OnEnable()
    {
        EventManager.winGame += CheckIsGameFinished;
    }

    private void OnDisable()
    {
        EventManager.winGame -= CheckIsGameFinished;
    }





    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheckIsGameFinished()
    {
        var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex > levelData.levelCount - 1)
        {
            nextButton.SetActive(false);
            gameFinishedText.SetActive(true);
        }
    }



    public void SkipToNextScene()
    {
        levelData.currentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

