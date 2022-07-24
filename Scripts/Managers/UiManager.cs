using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject loseGameCanvas;
    [SerializeField] GameObject winGameCanvas;


    //inspectordan ayarlancak þekil: start canvas açýk býrakýlacak. diðerleri kapalý olacak.

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



    //adam dans etme animasyonu yapýyor.
    //next e basýnca sonraki sahne yükleniyor.

    void SwitchToWinState()
    {
        //kutlama particle ý çýkacak.
        //adam dans ediyor.
        winGameCanvas.SetActive(true);
    }

    void SwitchToLoseState()
    {
        loseGameCanvas.SetActive(true);
        //merdivenler rigidbody eklemek
    }

}
