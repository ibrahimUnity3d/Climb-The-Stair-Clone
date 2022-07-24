using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float startStepDurationXZ = 0.2f;
    [SerializeField] UpgradeData upgradeData;

    float currentStepDurationXZ;
    float positionY;


    #region OnEnableDisable
    void OnEnable()
    {
       EventManager.newStepTransform += MoveToNewStep;
    }

    void OnDisable()
    {
       EventManager.newStepTransform -= MoveToNewStep;
    }
    #endregion

    private void Start()
    {
        currentStepDurationXZ = startStepDurationXZ;
    }

    public void UpdateStepDuration()
    {
        //startta hizimiz 1 oldugu icin
        // guncel hiz * guncel sure = 1* starttaki sure 
        currentStepDurationXZ = startStepDurationXZ / upgradeData.currentSpeedValue;
    }



    void MoveToNewStep(Vector3 newStepPosition, Quaternion newStepRotation)
    {
        //transform.position = position;
        transform.DOMoveX(newStepPosition.x, startStepDurationXZ);
        transform.DOMoveZ(newStepPosition.z, startStepDurationXZ);

        positionY = newStepPosition.y;
        transform.rotation = newStepRotation;
    }


    public void MoveToPosionY()
    {
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
    }

}
