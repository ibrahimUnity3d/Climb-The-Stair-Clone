using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StairStepCreator : MonoBehaviour
{
    [SerializeField] GameObject stepPrefab;
    [SerializeField] GameObject player;
    [SerializeField] Transform stepParentTransform;
    [SerializeField] int currentStepIndex = 0, stepCapasityOfCircle = 24;
    [SerializeField] float heightOfStep, distanceToCenter;
    StaminaSystem staminaSystemScript;
    Vector3 playerPosition = new Vector3(0.1f,0.1f,-0.5f);
    Quaternion playerRotation = Quaternion.Euler(0,15,0);
    float stepRotationFactor;
    bool isHalfStep;


    private void OnEnable()
    {
        EventManager.createAStep += CreateStep;
    }


    private void OnDisable()
    {
        EventManager.createAStep -= CreateStep;
    }


    // Start is called before the first frame update
    void Start()
    {
        stepRotationFactor = 360 / stepCapasityOfCircle;
        heightOfStep = 0.4f /6;
        staminaSystemScript = player.GetComponent<StaminaSystem>();
    }

 

    public void CreateStep()
    {
        GameObject newStep = Instantiate(stepPrefab, stepParentTransform, false);

        float rotationY;
        Quaternion rotation;
        Vector3 position;
        GetNewStepTransform(out rotationY, out rotation, out position);


        //transform ve pozisyon bilgilerimizi yayýnlýyoruz.
        EventManager.newStepTransform(playerPosition, playerRotation);
        EventManager.newStepPositionY(position.y);


        newStep.transform.localPosition = position;
        newStep.transform.localRotation = rotation;
       

        playerPosition = position;
        playerRotation = rotation;

        currentStepIndex++;
    }


    private void GetNewStepTransform(out float rotationY, out Quaternion rotation, out Vector3 position)
    {
        GetNewStepsRotation(out rotationY, out rotation);

        position = GetNewStepsPosition(rotationY);
    }

    void GetNewStepsRotation(out float rotationY, out Quaternion rotation)
    {
        rotationY = stepRotationFactor * (currentStepIndex % stepCapasityOfCircle);
        rotation = Quaternion.Euler(0, -rotationY, 0);
    }


    Vector3 GetNewStepsPosition(float rotationY)
    {
        var positionY = currentStepIndex * heightOfStep;

        var position = Vector3.zero;

        position.x = Mathf.Cos((rotationY - 90) * Mathf.Deg2Rad);
        position.z = Mathf.Sin((rotationY - 90) * Mathf.Deg2Rad);

        position *= distanceToCenter;

        position.y = positionY;
        return position;
    }
}
    