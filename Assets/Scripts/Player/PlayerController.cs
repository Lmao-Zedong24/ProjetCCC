using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static InputController;

public class PlayerController : MonoBehaviour, IPlayerActions
{
    @InputController _controller;
    Arm[] Arms;


    // Start is called before the first frame update
    // Update is called once per frame

    private void Awake()
    {
        _controller = new @InputController();
        _controller.Enable();
        _controller.Player.SetCallbacks(this);

        Arms = GetComponentsInChildren<Arm>();
    }
    void Update()
    {
        InteractArm(_controller.Player.Arm1.phase, 0);

        InteractArm(_controller.Player.Arm1.phase, 1);

        InteractArm(_controller.Player.Arm1.phase, 2);

        //test
        //Arms[0].ExtendArm();
    }

    private void InteractArm(InputAction.CallbackContext input, int i)
    {
        if (i < 0 || i >= Arms.Length)
            return;

        if (input.started)
            Arms[i].ExtendArm();

        if (input.canceled)
            Arms[i].RetractArm();
    }

    private void InteractArm(InputActionPhase phase, int i)
    {
        if (i < 0 || i >= Arms.Length)
            return;

        if (phase == InputActionPhase.Started)
            Arms[i].ExtendArm();

        if (phase == InputActionPhase.Canceled)
            Arms[i].RetractArm();
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
}
