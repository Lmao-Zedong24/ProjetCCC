using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static InputController;
using UnityEditor.UIElements;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine.EventSystems;
#endif

public class PlayerController : MonoBehaviour, IPlayerActions
{
    @InputController    _controller;
    Arm[]               _arms;
    Rigidbody           _mainBody;
    Collider            _collider;
    HashSet<Arm>        _sticky;
    FixedJoint          _linkedBody;

    RigidbodyConstraints _mainConstraints;

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

        _sticky = new HashSet<Arm>();
        _mainConstraints = _mainBody.constraints;
        _linkedBody = null;


        float radius = transform.localScale.x / 3.5f;
        float teta = Mathf.PI / 6 + 2 * Mathf.PI / 3;
        for (int i = 0; i < _arms.Length; i++)
        {
            float val = teta - 2 * Mathf.PI * i / (float)_arms.Length;
            //_arms[i].transform.rotation = Quaternion.identity;
            _arms[i].SetSpawnLocalPos(new Vector2(radius * Mathf.Cos(val),
                                                    radius * Mathf.Sin(val)));

            var childColliders = _arms[i].GetComponentsInChildren<Collider>();

            for (int j = 0; j < childColliders.Length; j++)
            {
                Physics.IgnoreCollision(_collider, childColliders[j]);

                for (int k = j + 1; k < childColliders.Length; k++)
                    Physics.IgnoreCollision(childColliders[j], childColliders[k]);
            }
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
        if (_linkedBody == null)
        {
            foreach (Arm arm in _arms)
            {
                if (arm.isSticking)
                {
                    _mainBody.constraints = RigidbodyConstraints.FreezeAll;
                    return;
                }
            }
        }

        _mainBody.constraints = _mainConstraints;
        transform.parent = null;
    }


    void Update()
    {
        InteractArm(_controller.Player.Arm1.phase, 0);
        InteractArm(_controller.Player.Arm1.phase, 1);
        InteractArm(_controller.Player.Arm1.phase, 2);


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

            if (input.started && !_linkedBody)
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

    private void RemoveLinkedBody()
    {
        if (_linkedBody != null)
        {
            Destroy(_linkedBody);
            _linkedBody = null;
        }
    }

    public void LinkBody(Rigidbody body)
    {
        if (_linkedBody == null)
        {
            _linkedBody = gameObject.AddComponent<FixedJoint>();
            _linkedBody.connectedBody = body;
            _mainBody.constraints = _mainConstraints;
        }
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

    public void OnStickyArm(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            foreach (var arm in _arms)
            {
                if (arm.armState == Arm.EArmState.StaticOut ||
                    arm.armState == Arm.EArmState.Extend)
                {
                    arm.isSticky = true;
                    _sticky.Add(arm);
                }
            }
        }

        if (context.canceled)
        {
            foreach (var arm in _sticky)
            {
                arm.isSticky = false;
                RemoveLinkedBody();
            }

            //RemoveLinkedBody();
            _sticky.Clear();
        }
    }

    public void OnPivotStickyArm(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (transform.parent == null)
            return;

        foreach (Arm arm in _sticky)
        {
            if (arm.isSticking)
            {
                arm.isSticky = false;
                RemoveLinkedBody();
                _mainBody.velocity = Vector3.zero;
                return;
            }
        }
    }


    #region Editor
#if UNITY_EDITOR

    [SerializeField] private bool GUIShowRetract = false;
    [SerializeField] private bool GUIShowImpact = false;
    [SerializeField] private bool GUIShowExtend = true;

    [CustomEditor(typeof(PlayerController))]
    [CanEditMultipleObjects]
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

                if (player.GUIShowImpact = EditorGUILayout.Foldout(player.GUIShowImpact, "Impact"))
                {
                    EditorGUI.indentLevel++;
                    player.armInfo.forceMultiplier = EditorGUILayout.FloatField("Force Multiplier", player.armInfo.forceMultiplier);
                    player.armInfo.rotationMultiplier = EditorGUILayout.FloatField("Rotation Multiplier", player.armInfo.rotationMultiplier);
                    player.armInfo.impactMode = (ArmInfo.ImpactMode)EditorGUILayout.EnumPopup("Impact Mode", player.armInfo.impactMode);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.Vector2Field("Impact Force", player.armInfo.lastImpactForce, GUILayout.MaxWidth(700f));
                    EditorGUILayout.FloatField(player.armInfo.lastImpactForce.magnitude);
                    EditorGUILayout.EndHorizontal();
                    EditorGUI.indentLevel++;
                }
            }

            if (player._arms != null)
            {
                EditorGUILayout.EnumFlagsField("Arm 1", player._arms[0].armState);
                EditorGUILayout.EnumFlagsField("Arm 2", player._arms[1].armState);
                EditorGUILayout.EnumFlagsField("Arm 3", player._arms[2].armState);
                EditorGUILayout.Space();

                EditorGUILayout.Toggle("Arm 1", player._arms[0].isSticky);
                EditorGUILayout.Toggle("Arm 2", player._arms[1].isSticky);
                EditorGUILayout.Toggle("Arm 3", player._arms[2].isSticky);
                EditorGUILayout.Space();
            }

        }
    }

#endif
    #endregion

}
