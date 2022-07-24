using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallWoodCreator : MonoBehaviour
{
    [SerializeField] GameObject smallWoodPrefab;


    #region OnEnableDisable
    private void OnEnable()
    {
        EventManager.newStepPositionY += CreateSmallWood;
    }


    private void OnDisable()
    {
        EventManager.newStepPositionY -= CreateSmallWood;
    }
    #endregion


    void CreateSmallWood(float positionY)
    {
        var position = new Vector3(0, positionY, 0);
        var newSmallWood = Instantiate(smallWoodPrefab, this.transform, false);
        newSmallWood.transform.localPosition = position;
    }
}
