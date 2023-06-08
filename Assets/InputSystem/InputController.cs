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
                },
                {
                    ""name"": ""StickyArm"",
                    ""type"": ""Button"",
                    ""id"": ""5e927169-b2f3-4f0b-b4d1-c3fa84184ac6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PivotStickyArm"",
                    ""type"": ""Button"",
                    ""id"": ""2e08e7b2-33c9-4eea-91e4-43a90589fd58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
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
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Arm1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0100e706-3a6d-4665-b1e0-809322d90ff3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickyArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""612da263-59e5-42cb-ad80-8e6ceb902426"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PivotStickyArm"",
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
                    ""id"": ""7ac1fa58-e90b-4bc1-9014-e8456d49f7b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn2"",
                    ""type"": ""Button"",
                    ""id"": ""096db272-0665-48bc-ab79-ac86f2babf7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn3"",
                    ""type"": ""Button"",
                    ""id"": ""81e7f14c-ba2e-4b35-b4e7-eefa4bc720e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn4"",
                    ""type"": ""Button"",
                    ""id"": ""4b955abd-7a2d-4cde-9f33-962a0b4f99ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn5"",
                    ""type"": ""Button"",
                    ""id"": ""2ec7d23c-b8db-4cce-96a1-71f514cba946"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn6"",
                    ""type"": ""Button"",
                    ""id"": ""26046d79-d016-4ba9-ace1-4ac522f4dde0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7d897b2a-3e15-4ed7-8828-3c77ba679f19"",
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
                    ""id"": ""24a34cc6-cb9d-492d-b451-0cbe6f7eb010"",
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
                    ""id"": ""691bc94b-b371-4e30-9b37-89dd666051c6"",
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
                    ""id"": ""94d9bee0-f2ed-41f8-a29a-98e53b9868b8"",
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
                    ""id"": ""bf0df2c3-4382-4565-a183-4a008f9c9acd"",
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
                    ""id"": ""9fab6b8e-6058-45cd-b522-b180aefe5cdb"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UICanvas"",
            ""id"": ""16c93aa0-28ed-43d4-9a83-d15e46eff99b"",
            ""actions"": [
                {
                    ""name"": ""OnArm1"",
                    ""type"": ""Button"",
                    ""id"": ""234b8b44-4207-44f7-b2d0-fe2e47b7a79c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnArm2"",
                    ""type"": ""Button"",
                    ""id"": ""24e7a3e5-06db-4be6-af76-c7e680f42433"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnArm3"",
                    ""type"": ""Button"",
                    ""id"": ""f6035dd5-fd15-4b4d-b330-3eda4c1034d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OffArm1"",
                    ""type"": ""Button"",
                    ""id"": ""565ae2b3-cb06-4167-a5ed-ad62dc11bad1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""OffArm2"",
                    ""type"": ""Button"",
                    ""id"": ""bca828b0-212c-4a45-b6bc-5fa3eb462fee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""OffArm3"",
                    ""type"": ""Button"",
                    ""id"": ""0352b6d9-86b5-4bb7-bb6c-1b8951ff9c08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1e621fa7-618a-4eb1-ab70-f25ce516ebfa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnArm1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df0aa93c-e897-4f1b-a130-aa05c1516af6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnArm2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9322701-1fc7-46f3-a629-7b9c663c63d9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnArm3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a84be97e-d3bf-4a77-98d6-30cc52c8758e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OffArm1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""221d0f7e-3c37-4f89-981c-ac3c3c78be5a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OffArm2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07a48efc-74e2-4f9d-94fd-f75015ae6f6c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OffArm3"",
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
        m_Player_StickyArm = m_Player.FindAction("StickyArm", throwIfNotFound: true);
        m_Player_PivotStickyArm = m_Player.FindAction("PivotStickyArm", throwIfNotFound: true);
        // SpawnerPos
        m_SpawnerPos = asset.FindActionMap("SpawnerPos", throwIfNotFound: true);
        m_SpawnerPos_Spawn1 = m_SpawnerPos.FindAction("Spawn1", throwIfNotFound: true);
        m_SpawnerPos_Spawn2 = m_SpawnerPos.FindAction("Spawn2", throwIfNotFound: true);
        m_SpawnerPos_Spawn3 = m_SpawnerPos.FindAction("Spawn3", throwIfNotFound: true);
        m_SpawnerPos_Spawn4 = m_SpawnerPos.FindAction("Spawn4", throwIfNotFound: true);
        m_SpawnerPos_Spawn5 = m_SpawnerPos.FindAction("Spawn5", throwIfNotFound: true);
        m_SpawnerPos_Spawn6 = m_SpawnerPos.FindAction("Spawn6", throwIfNotFound: true);
        // UICanvas
        m_UICanvas = asset.FindActionMap("UICanvas", throwIfNotFound: true);
        m_UICanvas_OnArm1 = m_UICanvas.FindAction("OnArm1", throwIfNotFound: true);
        m_UICanvas_OnArm2 = m_UICanvas.FindAction("OnArm2", throwIfNotFound: true);
        m_UICanvas_OnArm3 = m_UICanvas.FindAction("OnArm3", throwIfNotFound: true);
        m_UICanvas_OffArm1 = m_UICanvas.FindAction("OffArm1", throwIfNotFound: true);
        m_UICanvas_OffArm2 = m_UICanvas.FindAction("OffArm2", throwIfNotFound: true);
        m_UICanvas_OffArm3 = m_UICanvas.FindAction("OffArm3", throwIfNotFound: true);
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
    private readonly InputAction m_Player_StickyArm;
    private readonly InputAction m_Player_PivotStickyArm;
    public struct PlayerActions
    {
        private @InputController m_Wrapper;
        public PlayerActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Arm1 => m_Wrapper.m_Player_Arm1;
        public InputAction @Arm2 => m_Wrapper.m_Player_Arm2;
        public InputAction @Arm3 => m_Wrapper.m_Player_Arm3;
        public InputAction @StickyArm => m_Wrapper.m_Player_StickyArm;
        public InputAction @PivotStickyArm => m_Wrapper.m_Player_PivotStickyArm;
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
                @StickyArm.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStickyArm;
                @StickyArm.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStickyArm;
                @StickyArm.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStickyArm;
                @PivotStickyArm.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPivotStickyArm;
                @PivotStickyArm.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPivotStickyArm;
                @PivotStickyArm.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPivotStickyArm;
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
                @StickyArm.started += instance.OnStickyArm;
                @StickyArm.performed += instance.OnStickyArm;
                @StickyArm.canceled += instance.OnStickyArm;
                @PivotStickyArm.started += instance.OnPivotStickyArm;
                @PivotStickyArm.performed += instance.OnPivotStickyArm;
                @PivotStickyArm.canceled += instance.OnPivotStickyArm;
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

    // UICanvas
    private readonly InputActionMap m_UICanvas;
    private IUICanvasActions m_UICanvasActionsCallbackInterface;
    private readonly InputAction m_UICanvas_OnArm1;
    private readonly InputAction m_UICanvas_OnArm2;
    private readonly InputAction m_UICanvas_OnArm3;
    private readonly InputAction m_UICanvas_OffArm1;
    private readonly InputAction m_UICanvas_OffArm2;
    private readonly InputAction m_UICanvas_OffArm3;
    public struct UICanvasActions
    {
        private @InputController m_Wrapper;
        public UICanvasActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnArm1 => m_Wrapper.m_UICanvas_OnArm1;
        public InputAction @OnArm2 => m_Wrapper.m_UICanvas_OnArm2;
        public InputAction @OnArm3 => m_Wrapper.m_UICanvas_OnArm3;
        public InputAction @OffArm1 => m_Wrapper.m_UICanvas_OffArm1;
        public InputAction @OffArm2 => m_Wrapper.m_UICanvas_OffArm2;
        public InputAction @OffArm3 => m_Wrapper.m_UICanvas_OffArm3;
        public InputActionMap Get() { return m_Wrapper.m_UICanvas; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UICanvasActions set) { return set.Get(); }
        public void SetCallbacks(IUICanvasActions instance)
        {
            if (m_Wrapper.m_UICanvasActionsCallbackInterface != null)
            {
                @OnArm1.started -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm1;
                @OnArm1.performed -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm1;
                @OnArm1.canceled -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm1;
                @OnArm2.started -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm2;
                @OnArm2.performed -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm2;
                @OnArm2.canceled -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm2;
                @OnArm3.started -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm3;
                @OnArm3.performed -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm3;
                @OnArm3.canceled -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOnArm3;
                @OffArm1.started -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm1;
                @OffArm1.performed -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm1;
                @OffArm1.canceled -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm1;
                @OffArm2.started -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm2;
                @OffArm2.performed -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm2;
                @OffArm2.canceled -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm2;
                @OffArm3.started -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm3;
                @OffArm3.performed -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm3;
                @OffArm3.canceled -= m_Wrapper.m_UICanvasActionsCallbackInterface.OnOffArm3;
            }
            m_Wrapper.m_UICanvasActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnArm1.started += instance.OnOnArm1;
                @OnArm1.performed += instance.OnOnArm1;
                @OnArm1.canceled += instance.OnOnArm1;
                @OnArm2.started += instance.OnOnArm2;
                @OnArm2.performed += instance.OnOnArm2;
                @OnArm2.canceled += instance.OnOnArm2;
                @OnArm3.started += instance.OnOnArm3;
                @OnArm3.performed += instance.OnOnArm3;
                @OnArm3.canceled += instance.OnOnArm3;
                @OffArm1.started += instance.OnOffArm1;
                @OffArm1.performed += instance.OnOffArm1;
                @OffArm1.canceled += instance.OnOffArm1;
                @OffArm2.started += instance.OnOffArm2;
                @OffArm2.performed += instance.OnOffArm2;
                @OffArm2.canceled += instance.OnOffArm2;
                @OffArm3.started += instance.OnOffArm3;
                @OffArm3.performed += instance.OnOffArm3;
                @OffArm3.canceled += instance.OnOffArm3;
            }
        }
    }
    public UICanvasActions @UICanvas => new UICanvasActions(this);
    public interface IPlayerActions
    {
        void OnArm1(InputAction.CallbackContext context);
        void OnArm2(InputAction.CallbackContext context);
        void OnArm3(InputAction.CallbackContext context);
        void OnStickyArm(InputAction.CallbackContext context);
        void OnPivotStickyArm(InputAction.CallbackContext context);
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
    public interface IUICanvasActions
    {
        void OnOnArm1(InputAction.CallbackContext context);
        void OnOnArm2(InputAction.CallbackContext context);
        void OnOnArm3(InputAction.CallbackContext context);
        void OnOffArm1(InputAction.CallbackContext context);
        void OnOffArm2(InputAction.CallbackContext context);
        void OnOffArm3(InputAction.CallbackContext context);
    }
}
