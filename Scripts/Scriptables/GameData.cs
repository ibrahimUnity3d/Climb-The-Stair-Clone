using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New GameData", menuName = "ScriptableObjects / GameData" )]
public class GameData : ScriptableObject
{
    public float speedFactor;
    public float staminaFactor;
    public float highScore;
    public float finishScore;

    public Vector3 highScorePosition;
}
