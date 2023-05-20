// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""23383a24-0d44-4db0-815b-55afa1bb50c1"",
            ""actions"": [
                {
                    ""name"": ""Arm1"",
                    ""type"": ""Button"",
                    ""id"": ""95be1f88-02e0-438c-b106-01e41aefc3bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Arm2"",
                    ""type"": ""Button"",
                    ""id"": ""a0e6675b-4011-4fea-b2cb-47252fdcb3f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Arm3"",
                    ""type"": ""Button"",
                    ""id"": ""e2816966-343e-417c-a625-4ec4c024c0f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a6433412-e520-46c0-b5d7-6b6d0d09145a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arm2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a0679a8-b302-405f-b147-1da76f275d75"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arm3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa5cc3d8-d594-415e-954c-8f45a65a69b5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arm1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SpawnerPos"",
            ""id"": ""6562f977-dc34-4fe1-91f3-fa7ae36b2233"",
            ""actions"": [
                {
                    ""name"": ""Spawn1"",
                    ""type"": ""Button"",
                    ""id"": ""83d07b55-2c28-4122-82f0-614a33bfbef7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn2"",
                    ""type"": ""Button"",
                    ""id"": ""6ff2c989-050a-4ea3-bf85-5f91fce47d07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn3"",
                    ""type"": ""Button"",
                    ""id"": ""4f12b069-9057-4961-b63f-e89eca7efa6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn4"",
                    ""type"": ""Button"",
                    ""id"": ""2fbd572c-4d3d-4b84-b977-0b061bef865c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn5"",
                    ""type"": ""Button"",
                    ""id"": ""10a17f0b-96c5-48e4-8a2d-d79253843ea3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn6"",
                    ""type"": ""Button"",
                    ""id"": ""fddc18b0-b2cc-4679-a606-5fcfd6ee299a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e978dd49-9cf4-464f-8999-0b2bdcac41a9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8ae2dc6-fd77-4f82-80e4-0dad42353945"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""485805b7-2364-43be-9b9a-b2774ecb7b79"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6e8d26d-0f4a-4dd0-8f64-7e2d5690e73a"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d5059d4-7bc5-469f-9639-4f12a671f2d3"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90236748-a60a-4e6d-978e-f4d0197663a5"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Arm1 = m_Player.FindAction("Arm1", throwIfNotFound: true);
        m_Player_Arm2 = m_Player.FindAction("Arm2", throwIfNotFound: true);
        m_Player_Arm3 = m_Player.FindAction("Arm3", throwIfNotFound: true);
        // SpawnerPos
        m_SpawnerPos = asset.FindActionMap("SpawnerPos", throwIfNotFound: true);
        m_SpawnerPos_Spawn1 = m_SpawnerPos.FindAction("Spawn1", throwIfNotFound: true);
        m_SpawnerPos_Spawn2 = m_SpawnerPos.FindAction("Spawn2", throwIfNotFound: true);
        m_SpawnerPos_Spawn3 = m_SpawnerPos.FindAction("Spawn3", throwIfNotFound: true);
        m_SpawnerPos_Spawn4 = m_SpawnerPos.FindAction("Spawn4", throwIfNotFound: true);
        m_SpawnerPos_Spawn5 = m_SpawnerPos.FindAction("Spawn5", throwIfNotFound: true);
        m_SpawnerPos_Spawn6 = m_SpawnerPos.FindAction("Spawn6", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Arm1;
    private readonly InputAction m_Player_Arm2;
    private readonly InputAction m_Player_Arm3;
    public struct PlayerActions
    {
        private @InputController m_Wrapper;
        public PlayerActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Arm1 => m_Wrapper.m_Player_Arm1;
        public InputAction @Arm2 => m_Wrapper.m_Player_Arm2;
        public InputAction @Arm3 => m_Wrapper.m_Player_Arm3;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Arm1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm1;
                @Arm1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm1;
                @Arm1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm1;
                @Arm2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm2;
                @Arm2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm2;
                @Arm2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm2;
                @Arm3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm3;
                @Arm3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm3;
                @Arm3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArm3;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Arm1.started += instance.OnArm1;
                @Arm1.performed += instance.OnArm1;
                @Arm1.canceled += instance.OnArm1;
                @Arm2.started += instance.OnArm2;
                @Arm2.performed += instance.OnArm2;
                @Arm2.canceled += instance.OnArm2;
                @Arm3.started += instance.OnArm3;
                @Arm3.performed += instance.OnArm3;
                @Arm3.canceled += instance.OnArm3;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // SpawnerPos
    private readonly InputActionMap m_SpawnerPos;
    private ISpawnerPosActions m_SpawnerPosActionsCallbackInterface;
    private readonly InputAction m_SpawnerPos_Spawn1;
    private readonly InputAction m_SpawnerPos_Spawn2;
    private readonly InputAction m_SpawnerPos_Spawn3;
    private readonly InputAction m_SpawnerPos_Spawn4;
    private readonly InputAction m_SpawnerPos_Spawn5;
    private readonly InputAction m_SpawnerPos_Spawn6;
    public struct SpawnerPosActions
    {
        private @InputController m_Wrapper;
        public SpawnerPosActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Spawn1 => m_Wrapper.m_SpawnerPos_Spawn1;
        public InputAction @Spawn2 => m_Wrapper.m_SpawnerPos_Spawn2;
        public InputAction @Spawn3 => m_Wrapper.m_SpawnerPos_Spawn3;
        public InputAction @Spawn4 => m_Wrapper.m_SpawnerPos_Spawn4;
        public InputAction @Spawn5 => m_Wrapper.m_SpawnerPos_Spawn5;
        public InputAction @Spawn6 => m_Wrapper.m_SpawnerPos_Spawn6;
        public InputActionMap Get() { return m_Wrapper.m_SpawnerPos; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpawnerPosActions set) { return set.Get(); }
        public void SetCallbacks(ISpawnerPosActions instance)
        {
            if (m_Wrapper.m_SpawnerPosActionsCallbackInterface != null)
            {
                @Spawn1.started -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn1;
                @Spawn1.performed -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn1;
                @Spawn1.canceled -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn1;
                @Spawn2.started -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn2;
                @Spawn2.performed -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn2;
                @Spawn2.canceled -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn2;
                @Spawn3.started -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn3;
                @Spawn3.performed -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn3;
                @Spawn3.canceled -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn3;
                @Spawn4.started -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn4;
                @Spawn4.performed -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn4;
                @Spawn4.canceled -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn4;
                @Spawn5.started -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn5;
                @Spawn5.performed -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn5;
                @Spawn5.canceled -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn5;
                @Spawn6.started -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn6;
                @Spawn6.performed -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn6;
                @Spawn6.canceled -= m_Wrapper.m_SpawnerPosActionsCallbackInterface.OnSpawn6;
            }
            m_Wrapper.m_SpawnerPosActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Spawn1.started += instance.OnSpawn1;
                @Spawn1.performed += instance.OnSpawn1;
                @Spawn1.canceled += instance.OnSpawn1;
                @Spawn2.started += instance.OnSpawn2;
                @Spawn2.performed += instance.OnSpawn2;
                @Spawn2.canceled += instance.OnSpawn2;
                @Spawn3.started += instance.OnSpawn3;
                @Spawn3.performed += instance.OnSpawn3;
                @Spawn3.canceled += instance.OnSpawn3;
                @Spawn4.started += instance.OnSpawn4;
                @Spawn4.performed += instance.OnSpawn4;
                @Spawn4.canceled += instance.OnSpawn4;
                @Spawn5.started += instance.OnSpawn5;
                @Spawn5.performed += instance.OnSpawn5;
                @Spawn5.canceled += instance.OnSpawn5;
                @Spawn6.started += instance.OnSpawn6;
                @Spawn6.performed += instance.OnSpawn6;
                @Spawn6.canceled += instance.OnSpawn6;
            }
        }
    }
    public SpawnerPosActions @SpawnerPos => new SpawnerPosActions(this);
    public interface IPlayerActions
    {
        void OnArm1(InputAction.CallbackContext context);
        void OnArm2(InputAction.CallbackContext context);
        void OnArm3(InputAction.CallbackContext context);
    }
    public interface ISpawnerPosActions
    {
        void OnSpawn1(InputAction.CallbackContext context);
        void OnSpawn2(InputAction.CallbackContext context);
        void OnSpawn3(InputAction.CallbackContext context);
        void OnSpawn4(InputAction.CallbackContext context);
        void OnSpawn5(InputAction.CallbackContext context);
        void OnSpawn6(InputAction.CallbackContext context);
    }
}
