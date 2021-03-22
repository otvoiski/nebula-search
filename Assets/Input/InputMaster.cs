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
                }
            ]
        },
        {
            ""name"": ""ToastTest"",
            ""id"": ""6f576464-1abd-43ca-bfdc-0b3fdfbf501b"",
            ""actions"": [
                {
                    ""name"": ""ShowToast"",
                    ""type"": ""Button"",
                    ""id"": ""c5cdb34a-ba61-4abb-a9a8-c520bfb08eb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a95a1c00-0a57-448b-b207-7d8b41b2dfd2"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ShowToast"",
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
        m_UI_ToggleBuildScreen = m_UI.FindAction("Toggle Build Screen", throwIfNotFound: true);
        m_UI_EscapeBuildScreen = m_UI.FindAction("Escape Build Screen", throwIfNotFound: true);
        // ToastTest
        m_ToastTest = asset.FindActionMap("ToastTest", throwIfNotFound: true);
        m_ToastTest_ShowToast = m_ToastTest.FindAction("ShowToast", throwIfNotFound: true);
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
    private readonly InputAction m_UI_ToggleBuildScreen;
    private readonly InputAction m_UI_EscapeBuildScreen;
    public struct UIActions
    {
        private @InputMaster m_Wrapper;
        public UIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleBuildScreen => m_Wrapper.m_UI_ToggleBuildScreen;
        public InputAction @EscapeBuildScreen => m_Wrapper.m_UI_EscapeBuildScreen;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @ToggleBuildScreen.started -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleBuildScreen;
                @ToggleBuildScreen.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleBuildScreen;
                @ToggleBuildScreen.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnToggleBuildScreen;
                @EscapeBuildScreen.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeBuildScreen;
                @EscapeBuildScreen.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeBuildScreen;
                @EscapeBuildScreen.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEscapeBuildScreen;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleBuildScreen.started += instance.OnToggleBuildScreen;
                @ToggleBuildScreen.performed += instance.OnToggleBuildScreen;
                @ToggleBuildScreen.canceled += instance.OnToggleBuildScreen;
                @EscapeBuildScreen.started += instance.OnEscapeBuildScreen;
                @EscapeBuildScreen.performed += instance.OnEscapeBuildScreen;
                @EscapeBuildScreen.canceled += instance.OnEscapeBuildScreen;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // ToastTest
    private readonly InputActionMap m_ToastTest;
    private IToastTestActions m_ToastTestActionsCallbackInterface;
    private readonly InputAction m_ToastTest_ShowToast;
    public struct ToastTestActions
    {
        private @InputMaster m_Wrapper;
        public ToastTestActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShowToast => m_Wrapper.m_ToastTest_ShowToast;
        public InputActionMap Get() { return m_Wrapper.m_ToastTest; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ToastTestActions set) { return set.Get(); }
        public void SetCallbacks(IToastTestActions instance)
        {
            if (m_Wrapper.m_ToastTestActionsCallbackInterface != null)
            {
                @ShowToast.started -= m_Wrapper.m_ToastTestActionsCallbackInterface.OnShowToast;
                @ShowToast.performed -= m_Wrapper.m_ToastTestActionsCallbackInterface.OnShowToast;
                @ShowToast.canceled -= m_Wrapper.m_ToastTestActionsCallbackInterface.OnShowToast;
            }
            m_Wrapper.m_ToastTestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ShowToast.started += instance.OnShowToast;
                @ShowToast.performed += instance.OnShowToast;
                @ShowToast.canceled += instance.OnShowToast;
            }
        }
    }
    public ToastTestActions @ToastTest => new ToastTestActions(this);
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
        void OnToggleBuildScreen(InputAction.CallbackContext context);
        void OnEscapeBuildScreen(InputAction.CallbackContext context);
    }
    public interface IToastTestActions
    {
        void OnShowToast(InputAction.CallbackContext context);
    }
}
