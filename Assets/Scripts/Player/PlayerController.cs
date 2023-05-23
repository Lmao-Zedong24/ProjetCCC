using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static InputController;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.EventSystems;
#endif

public class PlayerController : MonoBehaviour, IPlayerActions
{
    @InputController _controller;
    Arm[]       _arms;
    Rigidbody   _mainBody;
    Collider    _collider;

    //arm coordinates (x,y) :
    //  R * (cos(0), sin(0))
    //  R * (cos(2PI/3), sin(2PI/3))
    //  R * (cos(4PI/3), sin(4PI/3))

    [SerializeField] private ArmInfo armInfo;

    //TODO : better player controller
    private void Awake()
    {
        _controller = new @InputController();
        _controller.Enable();
        _controller.Player.SetCallbacks(this);

        _arms = GetComponentsInChildren<Arm>();
        _mainBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        float radius =  transform.localScale.x / 4; 
        float teta =    Mathf.PI / 2; 
        for(int i = 0; i < _arms.Length; i++)
        {
            float val = teta - 2 * Mathf.PI * i / 3f;
            _arms[i].SetSpawnLocalPos(new Vector2(   radius * Mathf.Cos(val),
                                                    radius * Mathf.Sin(val)));

            Physics.IgnoreCollision(_collider, _arms[i].colHand);
        }

        //var allTrans = GetComponentsInChildren<Transform>();

        //foreach(Transform trans in allTrans)
        //{
        //    if (trans.CompareTag("MainBody"))
        //    {
        //        _mainBody = trans;
        //        break;
        //    }
        //}
    }
    void FixedUpdate()
    {
        foreach(Arm arm in _arms)
        {
            if (_arms[0].hasCollission)
            {
                _mainBody.useGravity = false;
                break;
            }

            _mainBody.useGravity = true;
        }
    }


    void Update()
    {
        InteractArm(_controller.Player.Arm1.phase, 0);
        InteractArm(_controller.Player.Arm1.phase, 1);
        InteractArm(_controller.Player.Arm1.phase, 2);

        //foreach (var arm in _arms)
        //    Debug.DrawLine(transform.position, arm.transform.position, Color.red, 1f);

        //transform.position = _mainBody.position;
        //transform.rotation = _mainBody.rotation;

        //_mainBody.localPosition = new Vector3();
        //_mainBody.rotation = Quaternion.identity;
    }

    private void InteractArm(InputAction.CallbackContext input, int i)
    {
        if (i < 0 || i >= _arms.Length)
            return;

        if (input.started || input.canceled)
        {
            _arms[i].SetupArmInfo(armInfo);

            if (input.started)
                _arms[i].ExtendArm();

            else if (input.canceled)
                _arms[i].RetractArm();
        }
    }

    private void InteractArm(InputActionPhase phase, int i)
    {
        if (i < 0 || i >= _arms.Length)
            return;

        if (phase == InputActionPhase.Started)
            _arms[i].ExtendArm();

        if (phase == InputActionPhase.Canceled)
            _arms[i].RetractArm();
    }

    public void OnArm1(InputAction.CallbackContext context)
    {
        InteractArm(context, 0);
    }

    public void OnArm2(InputAction.CallbackContext context)
    {
        InteractArm(context, 1);
    }

    public void OnArm3(InputAction.CallbackContext context)
    {
        InteractArm(context, 2);
    }

    #region Editor
#if UNITY_EDITOR

    [SerializeField] private bool GUIShowRetract = true;
    [SerializeField] private bool GUIShowExtend = true;

    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : Editor
    {
        private SerializedProperty _armInfoProperty;

        private void OnEnable()
        {
            _armInfoProperty = serializedObject.FindProperty("armInfo");
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            //EditorGUILayout.Space();

            PlayerController player = (PlayerController)target;

            EditorGUILayout.PropertyField(_armInfoProperty);
            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();

            if (player.armInfo != null)
            {
                player.armInfo.maxLenght = EditorGUILayout.Slider("Max Lenght", player.armInfo.maxLenght, 0f, 50f);
                EditorGUILayout.Space();

                if (player.GUIShowExtend = EditorGUILayout.Foldout(player.GUIShowExtend, "Extend"))
                {
                    EditorGUI.indentLevel++;
                    player.armInfo.minSpeedExtend = EditorGUILayout.Slider("Min Speed", player.armInfo.minSpeedExtend, 0f, 100f);
                    player.armInfo.maxSpeedExtend = EditorGUILayout.Slider("Max Speed", player.armInfo.maxSpeedExtend, 0f, 100f);
                    player.armInfo.accelerationExtend = EditorGUILayout.Slider("Acceleration", player.armInfo.accelerationExtend, 0f, 100f);
                    EditorGUI.indentLevel--;
                    EditorGUILayout.Space();
                }

                if (player.GUIShowRetract = EditorGUILayout.Foldout(player.GUIShowRetract, "Retract"))
                { 
                    EditorGUI.indentLevel++;
                    player.armInfo.minSpeedRetract = EditorGUILayout.Slider("Min Speed", player.armInfo.minSpeedRetract, 0f, 100f);
                    player.armInfo.maxSpeedRetract = EditorGUILayout.Slider("Max Speed", player.armInfo.maxSpeedRetract, 0f, 100f);
                    player.armInfo.accelerationRetract = EditorGUILayout.Slider("Acceleration", player.armInfo.accelerationRetract, 0f, 100f);
                    EditorGUI.indentLevel--;
                    EditorGUILayout.Space();
                }
            }

            if (player._arms != null)
            {
                EditorGUILayout.EnumFlagsField("Arm 1", player._arms[0].armState);
                EditorGUILayout.EnumFlagsField("Arm 2", player._arms[1].armState);
                EditorGUILayout.EnumFlagsField("Arm 3", player._arms[2].armState);
                EditorGUILayout.Space();
            }

        }
    }

#endif
    #endregion

}
