using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] CanvasJay _canva;
    @InputController    _inputs;


    public int[] armExtendNum { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        _inputs = new @InputController();

        _canva.SetArmInputKey(1, _inputs.Player.Arm1.GetBindingDisplayString().Substring(6));
        _canva.SetArmInputKey(0, _inputs.Player.Arm2.GetBindingDisplayString().Substring(6));
        _canva.SetArmInputKey(2, _inputs.Player.Arm3.GetBindingDisplayString().Substring(6));
    }
}
