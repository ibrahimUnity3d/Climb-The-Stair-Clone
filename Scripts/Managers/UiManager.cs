using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject loseGameCanvas;
    [SerializeField] GameObject winGameCanvas;


    //inspectordan ayarlancak �ekil: start canvas a��k b�rak�lacak. di�erleri kapal� olacak.

    #region onenableDisable
    private void OnEnable()
    {
        EventManager.playGame += SwitchToPlayState;
        EventManager.loseGame += SwitchToLoseState;
        EventManager.winGame += SwitchToWinState;
    }

    private void OnDisable()
    {
        EventManager.playGame -= SwitchToPlayState;
        EventManager.loseGame -= SwitchToLoseState;
        EventManager.winGame -= SwitchToWinState;
    }
    #endregion


    private void Start()
    {
        SwitchToStartState();
    }



    void SwitchToStartState()
    {

        startCanvas.SetActive(true);
    }


    void SwitchToPlayState()
    {
        startCanvas.SetActive(false);
    }



    //adam dans etme animasyonu yap�yor.
    //next e bas�nca sonraki sahne y�kleniyor.

    void SwitchToWinState()
    {
        //kutlama particle � ��kacak.
        //adam dans ediyor.
        winGameCanvas.SetActive(true);
    }

    void SwitchToLoseState()
    {
        loseGameCanvas.SetActive(true);
        //merdivenler rigidbody eklemek
    }

}
