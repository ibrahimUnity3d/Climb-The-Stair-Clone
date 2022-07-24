using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetPosition : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.newStepPositionY += UpdateCameraTargetYPosition;
    }

    private void OnDisable()
    {
        EventManager.newStepPositionY -= UpdateCameraTargetYPosition;
    }



    void UpdateCameraTargetYPosition(float positionY)
    {
        transform.position = new Vector3(0, positionY, 0);
    }
}
