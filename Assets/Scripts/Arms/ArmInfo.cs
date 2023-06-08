using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEditor.Animations;
//using UnityEngine.EventSystems;
//#endif

[CreateAssetMenu(menuName = "ArmInfo")]
public class ArmInfo : ScriptableObject
{
    public enum ImpactMode
    {
        ArmVelocity,
        ArmExtendLength,
        SetValue
    }

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

    [Header("Force")]
    public ImpactMode impactMode = ImpactMode.ArmVelocity;
    public float forceMultiplier = 1f;
    public float rotationMultiplier = 1f;
    public Vector2 lastImpactForce { get; set; }


    //    #region Editor
    //#if UNITY_EDITOR

    //    [SerializeField] private bool GUIShowRetract = true;
    //    [SerializeField] private bool GUIShowExtend = true;

    //    [CustomEditor(typeof(PlayerController))]
    //    [CanEditMultipleObjects]
    //    public class ArmInfoEditor : Editor
    //    {
    //        public override void OnInspectorGUI()
    //        {
    //            base.OnInspectorGUI();
    //            EditorGUILayout.Space();

    //            EditorGUILayout.TextField("Impact");
    //            EditorGUILayout.Space();


    //        }

    //        //public float minSpeedExtend = 10f;
    //        //public float minSpeedExtend = 10f;
    //        //public float minSpeedExtend = 10f;
    //    }

    //#endif
    //    #endregion
}
