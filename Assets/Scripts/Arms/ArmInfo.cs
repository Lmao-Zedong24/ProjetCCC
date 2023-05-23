using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.EventSystems;
#endif

[CreateAssetMenu(menuName = "ArmInfo")]
public class ArmInfo : ScriptableObject
{
    [Header("Dimentions")]
    public float maxLenght = 10f;

    [Header("Extend")]
    public float minSpeedExtend = 10f;
    public float maxSpeedExtend = 40f;
    public float accelerationExtend = 10f;

    [Header("Retract")]
    public float minSpeedRetract = 20f;
    public float maxSpeedRetract = 20f;
    public float accelerationRetract = 40f;
}
