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
            ""name"": ""Menu"",
            ""id"": ""de14ebf8-ba8f-4b89-99ca-681af0287c57"",
            ""actions"": [
                {
                    ""name"": ""Toggle Menu Screen"",
                    ""type"": ""Button"",
                    ""id"": ""affe604e-a2fc-4f98-8038-f428b1c9f1f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
        },
        {
            ""name"": ""BuildMode"",
            ""id"": ""b461159a-ff9c-4e6c-9569-52ca5804e2c4"",
            ""actions"": [
                {
                    ""name"": ""Toggle Build Menu"",
                    ""type"": ""Button"",
                    ""id"": ""b8f90ab2-82ad-448a-b206-c4df3221d4f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape Build Menu"",
                    ""type"": ""Button"",
                    ""id"": ""ff660156-aaa5-4d1a-bb04-e6cba812f2b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click To Contruct"",
                    ""type"": ""Button"",
                    ""id"": ""7ff678e0-e732-445e-bf16-4f3df274f5d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3fe7af2e-be7b-4a9c-bb20-27a399757025"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Toggle Build Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22399d30-dcaf-4a16-921b-1f080205c417"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Escape Build Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c09d36d-db46-46a4-bacd-a5ae375852be"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Click To Contruct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MachineScreen"",
            ""id"": ""f9164149-132c-4be5-8180-4cb5203a003c"",
            ""actions"": [
                {
                    ""name"": ""Open Machine Screen"",
                    ""type"": ""Button"",
                    ""id"": ""8a7ff586-880e-4121-aea8-2f7f7e198c07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape Machine Screen"",
                    ""type"": ""Button"",
                    ""id"": ""575828f5-75c2-4311-862f-466e5a96cce3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dde01ba0-2688-4933-a1e4-9832988cda5b"",
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
                    ""id"": ""36f0947d-f861-48ed-8486-521daaaa86ee"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Open Machine Screen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f2397bb-0728-413c-b848-1e55320dc215"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Open Machine Screen"",
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
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_ToggleMenuScreen = m_Menu.FindAction("Toggle Menu Screen", throwIfNotFound: true);
        // Developer
        m_Developer = asset.FindActionMap("Developer", throwIfNotFound: true);
        m_Developer_ToggleConsole = m_Developer.FindAction("Toggle Console", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        // BuildMode
        m_BuildMode = asset.FindActionMap("BuildMode", throwIfNotFound: true);
        m_BuildMode_ToggleBuildMenu = m_BuildMode.FindAction("Toggle Build Menu", throwIfNotFound: true);
        m_BuildMode_EscapeBuildMenu = m_BuildMode.FindAction("Escape Build Menu", throwIfNotFound: true);
        m_BuildMode_ClickToContruct = m_BuildMode.FindAction("Click To Contruct", throwIfNotFound: true);
        // MachineScreen
        m_MachineScreen = asset.FindActionMap("MachineScreen", throwIfNotFound: true);
        m_MachineScreen_OpenMachineScreen = m_MachineScreen.FindAction("Open Machine Screen", throwIfNotFound: true);
        m_MachineScreen_EscapeMachineScreen = m_MachineScreen.FindAction("Escape Machine Screen", throwIfNotFound: true);
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

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_ToggleMenuScreen;
    public struct MenuActions
    {
        private @InputMaster m_Wrapper;
        public MenuActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleMenuScreen => m_Wrapper.m_Menu_ToggleMenuScreen;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @ToggleMenuScreen.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnToggleMenuScreen;
                @ToggleMenuScreen.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnToggleMenuScreen;
                @ToggleMenuScreen.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnToggleMenuScreen;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleMenuScreen.started += instance.OnToggleMenuScreen;
                @ToggleMenuScreen.performed += instance.OnToggleMenuScreen;
                @ToggleMenuScreen.canceled += instance.OnToggleMenuScreen;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

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

    // BuildMode
    private readonly InputActionMap m_BuildMode;
    private IBuildModeActions m_BuildModeActionsCallbackInterface;
    private readonly InputAction m_BuildMode_ToggleBuildMenu;
    private readonly InputAction m_BuildMode_EscapeBuildMenu;
    private readonly InputAction m_BuildMode_ClickToContruct;
    public struct BuildModeActions
    {
        private @InputMaster m_Wrapper;
        public BuildModeActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleBuildMenu => m_Wrapper.m_BuildMode_ToggleBuildMenu;
        public InputAction @EscapeBuildMenu => m_Wrapper.m_BuildMode_EscapeBuildMenu;
        public InputAction @ClickToContruct => m_Wrapper.m_BuildMode_ClickToContruct;
        public InputActionMap Get() { return m_Wrapper.m_BuildMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BuildModeActions set) { return set.Get(); }
        public void SetCallbacks(IBuildModeActions instance)
        {
            if (m_Wrapper.m_BuildModeActionsCallbackInterface != null)
            {
                @ToggleBuildMenu.started -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnToggleBuildMenu;
                @ToggleBuildMenu.performed -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnToggleBuildMenu;
                @ToggleBuildMenu.canceled -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnToggleBuildMenu;
                @EscapeBuildMenu.started -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnEscapeBuildMenu;
                @EscapeBuildMenu.performed -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnEscapeBuildMenu;
                @EscapeBuildMenu.canceled -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnEscapeBuildMenu;
                @ClickToContruct.started -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnClickToContruct;
                @ClickToContruct.performed -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnClickToContruct;
                @ClickToContruct.canceled -= m_Wrapper.m_BuildModeActionsCallbackInterface.OnClickToContruct;
            }
            m_Wrapper.m_BuildModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleBuildMenu.started += instance.OnToggleBuildMenu;
                @ToggleBuildMenu.performed += instance.OnToggleBuildMenu;
                @ToggleBuildMenu.canceled += instance.OnToggleBuildMenu;
                @EscapeBuildMenu.started += instance.OnEscapeBuildMenu;
                @EscapeBuildMenu.performed += instance.OnEscapeBuildMenu;
                @EscapeBuildMenu.canceled += instance.OnEscapeBuildMenu;
                @ClickToContruct.started += instance.OnClickToContruct;
                @ClickToContruct.performed += instance.OnClickToContruct;
                @ClickToContruct.canceled += instance.OnClickToContruct;
            }
        }
    }
    public BuildModeActions @BuildMode => new BuildModeActions(this);

    // MachineScreen
    private readonly InputActionMap m_MachineScreen;
    private IMachineScreenActions m_MachineScreenActionsCallbackInterface;
    private readonly InputAction m_MachineScreen_OpenMachineScreen;
    private readonly InputAction m_MachineScreen_EscapeMachineScreen;
    public struct MachineScreenActions
    {
        private @InputMaster m_Wrapper;
        public MachineScreenActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenMachineScreen => m_Wrapper.m_MachineScreen_OpenMachineScreen;
        public InputAction @EscapeMachineScreen => m_Wrapper.m_MachineScreen_EscapeMachineScreen;
        public InputActionMap Get() { return m_Wrapper.m_MachineScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MachineScreenActions set) { return set.Get(); }
        public void SetCallbacks(IMachineScreenActions instance)
        {
            if (m_Wrapper.m_MachineScreenActionsCallbackInterface != null)
            {
                @OpenMachineScreen.started -= m_Wrapper.m_MachineScreenActionsCallbackInterface.OnOpenMachineScreen;
                @OpenMachineScreen.performed -= m_Wrapper.m_MachineScreenActionsCallbackInterface.OnOpenMachineScreen;
                @OpenMachineScreen.canceled -= m_Wrapper.m_MachineScreenActionsCallbackInterface.OnOpenMachineScreen;
                @EscapeMachineScreen.started -= m_Wrapper.m_MachineScreenActionsCallbackInterface.OnEscapeMachineScreen;
                @EscapeMachineScreen.performed -= m_Wrapper.m_MachineScreenActionsCallbackInterface.OnEscapeMachineScreen;
                @EscapeMachineScreen.canceled -= m_Wrapper.m_MachineScreenActionsCallbackInterface.OnEscapeMachineScreen;
            }
            m_Wrapper.m_MachineScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenMachineScreen.started += instance.OnOpenMachineScreen;
                @OpenMachineScreen.performed += instance.OnOpenMachineScreen;
                @OpenMachineScreen.canceled += instance.OnOpenMachineScreen;
                @EscapeMachineScreen.started += instance.OnEscapeMachineScreen;
                @EscapeMachineScreen.performed += instance.OnEscapeMachineScreen;
                @EscapeMachineScreen.canceled += instance.OnEscapeMachineScreen;
            }
        }
    }
    public MachineScreenActions @MachineScreen => new MachineScreenActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IMenuActions
    {
        void OnToggleMenuScreen(InputAction.CallbackContext context);
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
    public interface IBuildModeActions
    {
        void OnToggleBuildMenu(InputAction.CallbackContext context);
        void OnEscapeBuildMenu(InputAction.CallbackContext context);
        void OnClickToContruct(InputAction.CallbackContext context);
    }
    public interface IMachineScreenActions
    {
        void OnOpenMachineScreen(InputAction.CallbackContext context);
        void OnEscapeMachineScreen(InputAction.CallbackContext context);
    }
}
