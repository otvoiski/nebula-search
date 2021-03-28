// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""de14ebf8-ba8f-4b89-99ca-681af0287c57"",
            ""actions"": [
                {
                    ""name"": ""Toggle Menu Screen"",
                    ""type"": ""Button"",
                    ""id"": ""affe604e-a2fc-4f98-8038-f428b1c9f1f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Build Screen"",
                    ""type"": ""Button"",
                    ""id"": ""7b1ea71f-90a2-463b-9f08-e8e616a132b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape Build Screen"",
                    ""type"": ""Button"",
                    ""id"": ""f540ec94-46a9-4ddb-a8b9-c780ce6a5c18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape Machine Screen"",
                    ""type"": ""Button"",
                    ""id"": ""65df057e-2351-470c-a6f2-c021f414b561"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""edaa0626-b16a-4823-8c2c-5d04d45011a8"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Toggle Build Screen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2c15bcf-5ba4-4d89-84bd-b554418d7eb5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Escape Build Screen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""085c1c62-ba80-4805-9233-7347c9e22fb7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Escape Machine Screen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ab1be56-3c13-40a7-88d2-ff93e3ded23d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Toggle Menu Screen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Developer"",
            ""id"": ""3dcc4b8d-92e7-4959-b42e-7465dbdc8a82"",
            ""actions"": [
                {
                    ""name"": ""Toggle Console"",
                    ""type"": ""Button"",
                    ""id"": ""e874a72c-8e3d-4ebd-8648-3ed69f0a6cf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""441c3593-b766-4e5e-8bcb-450896c55e04"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Toggle Console"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""c0864925-abf2-449f-9708-f60853523919"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""919d575b-7e20-4914-8158-7a6f9f6c9e90"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""fd870bcf-7d90-4a8e-9f8b-a04f160f6486"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""20ca4e05-560d-4b3d-a298-bfc5e9252921"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9dc6fae3-62dc-4584-a81d-6013f9db9890"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0b2fe890-26f3-4cac-8cc0-4c71cc7614bf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1acb2c56-3b38-442c-820b-49e49d78a63c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""65275efe-027e-4313-879a-2eef7c16605d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e7844b47-3e73-4d69-ad3c-4ef4cd46fcc8"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_ToggleMenuScreen = m_UI.FindAction("Toggle Menu Screen", throwIfNotFound: true);
        m_UI_ToggleBuildScreen = m_UI.FindAction("Toggle Build Screen", throwIfNotFound: true);
        m_UI_EscapeBuildScreen = m_UI.FindAction("Escape Build Screen", throwIfNotFound: true);
        m_UI_EscapeMachineScreen = m_UI.FindAction("Escape Machine Screen", throwIfNotFound: true);
        // Developer
        m_Developer = asset.FindActionMap("Developer", throwIfNotFound: true);
        m_Developer_ToggleConsole = m_Developer.FindAction("Toggle Console", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_ToggleMenuScreen;
    private readonly InputAction m_UI_ToggleBuildScreen;
    private readonly InputAction m_UI_EscapeBuildScreen;
    private readonly InputAction m_UI_EscapeMachineScreen;
    public struct UIActions
    {
        private @InputMaster m_Wrapper;
        public UIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleMenuScreen => m_Wrapper.m_UI_ToggleMenuScreen;
        public InputAction @ToggleBuildScreen => m_Wrapper.m_UI_ToggleBuildScreen;
        public InputAction @EscapeBuildScreen => m_Wrapper.m_UI_EscapeBuildScreen;
        public InputAction @EscapeMachineScreen => m_Wrapper.m_UI_EscapeMachineScreen;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @ToggleMenuScreen.started -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleMenuScreen;
                @ToggleMenuScreen.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleMenuScreen;
                @ToggleMenuScreen.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleMenuScreen;
                @ToggleBuildScreen.started -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleBuildScreen;
                @ToggleBuildScreen.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleBuildScreen;
                @ToggleBuildScreen.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleBuildScreen;
                @EscapeBuildScreen.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeBuildScreen;
                @EscapeBuildScreen.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeBuildScreen;
                @EscapeBuildScreen.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeBuildScreen;
                @EscapeMachineScreen.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeMachineScreen;
                @EscapeMachineScreen.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeMachineScreen;
                @EscapeMachineScreen.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeMachineScreen;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleMenuScreen.started += instance.OnToggleMenuScreen;
                @ToggleMenuScreen.performed += instance.OnToggleMenuScreen;
                @ToggleMenuScreen.canceled += instance.OnToggleMenuScreen;
                @ToggleBuildScreen.started += instance.OnToggleBuildScreen;
                @ToggleBuildScreen.performed += instance.OnToggleBuildScreen;
                @ToggleBuildScreen.canceled += instance.OnToggleBuildScreen;
                @EscapeBuildScreen.started += instance.OnEscapeBuildScreen;
                @EscapeBuildScreen.performed += instance.OnEscapeBuildScreen;
                @EscapeBuildScreen.canceled += instance.OnEscapeBuildScreen;
                @EscapeMachineScreen.started += instance.OnEscapeMachineScreen;
                @EscapeMachineScreen.performed += instance.OnEscapeMachineScreen;
                @EscapeMachineScreen.canceled += instance.OnEscapeMachineScreen;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // Developer
    private readonly InputActionMap m_Developer;
    private IDeveloperActions m_DeveloperActionsCallbackInterface;
    private readonly InputAction m_Developer_ToggleConsole;
    public struct DeveloperActions
    {
        private @InputMaster m_Wrapper;
        public DeveloperActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleConsole => m_Wrapper.m_Developer_ToggleConsole;
        public InputActionMap Get() { return m_Wrapper.m_Developer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeveloperActions set) { return set.Get(); }
        public void SetCallbacks(IDeveloperActions instance)
        {
            if (m_Wrapper.m_DeveloperActionsCallbackInterface != null)
            {
                @ToggleConsole.started -= m_Wrapper.m_DeveloperActionsCallbackInterface.OnToggleConsole;
                @ToggleConsole.performed -= m_Wrapper.m_DeveloperActionsCallbackInterface.OnToggleConsole;
                @ToggleConsole.canceled -= m_Wrapper.m_DeveloperActionsCallbackInterface.OnToggleConsole;
            }
            m_Wrapper.m_DeveloperActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleConsole.started += instance.OnToggleConsole;
                @ToggleConsole.performed += instance.OnToggleConsole;
                @ToggleConsole.canceled += instance.OnToggleConsole;
            }
        }
    }
    public DeveloperActions @Developer => new DeveloperActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Inventory;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Inventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IUIActions
    {
        void OnToggleMenuScreen(InputAction.CallbackContext context);
        void OnToggleBuildScreen(InputAction.CallbackContext context);
        void OnEscapeBuildScreen(InputAction.CallbackContext context);
        void OnEscapeMachineScreen(InputAction.CallbackContext context);
    }
    public interface IDeveloperActions
    {
        void OnToggleConsole(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
}
