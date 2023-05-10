using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    @InputController _controller;


    // Start is called before the first frame update
    // Update is called once per frame

    private void Awake()
    {
        InputAction[] armInputs = {    _controller.Player.Arm1,
                                        _controller.Player.Arm2,
                                        _controller.Player.Arm3 };

        for (int i = 0; i < armInputs.Length; i++)
        {
            armInputs[i].performed += ligma;  //on pressed and on release
        }
    }
    void Update()
    {
    }

    //TODO : create llamda/action for all 3 arms
    void ligma(InputAction.CallbackContext input)
    {
        if (input.started)
        {

        }

        if (input.canceled)
        {

        }
    }
}
