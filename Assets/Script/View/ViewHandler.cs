using Assets.Script.Data.Enum;
using Assets.Script.Data.Util.DeveloperConsole;
using Assets.Script.View.Enum;
using Assets.Script.View.Model;
using Assets.Script.View.Service;
using System;
using Assets.Script.Util;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.Script.View
{
    public class ViewHandler : MonoBehaviour
    {
        public const string NAME = "VIEW HANDLER";

        [Header("UI")] public static int LimitTextConsoleItem;
        public WindowsMachineService WindowsMachineService { get; private set; }
        public DeveloperConsoleBehaviour DeveloperConsoleBehaviour { get; private set; }
        public BuilderScreenService BuilderScreenService { get; private set; }
        public MainScreenModel MainScreen { get; private set; }

        public InputMaster Input;

        [SerializeField] private bool _isOpen;

        private void Awake()
        {
            gameObject.name = NAME;

            LimitTextConsoleItem = 100;

            #region Input

            Input = new InputMaster();

            #endregion Input

            #region General

            var viewHandler = GameObject.Find(NAME)
                .GetComponent<ViewHandler>();

            var mainScreen = viewHandler.transform.Find("MainScreen");

            // Main Screen
            MainScreen = mainScreen.gameObject
                .AddComponent<MainScreenModel>();
            MainScreen.BottomBar = mainScreen.GetChild((int)MainScreenEnum.BottomBar);
            MainScreen.Toast = mainScreen.GetChild((int)MainScreenEnum.Toast);

            // Windows Machines
            MainScreen.WindowsMachine = mainScreen.GetChild((int)MainScreenEnum.WindowsMachine).gameObject
                .AddComponent<WindowsMachineModel>();
            MainScreen.WindowsMachine.Title = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Title);
            MainScreen.WindowsMachine.Inventory = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Inventory);
            MainScreen.WindowsMachine.IO = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.IO);
            MainScreen.WindowsMachine.Button = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Button);
            MainScreen.WindowsMachine.ProcessMenu = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.ProcessMenu);
            MainScreen.WindowsMachine.Info = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Info);

            // Build Screen
            MainScreen.BuildScreen = mainScreen.GetChild((int)MainScreenEnum.BuildScreen).gameObject
                .AddComponent<BuildScreenModel>();
            MainScreen.BuildScreen.BuildMenu = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildMenu);
            MainScreen.BuildScreen.BuildList = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildList);
            MainScreen.BuildScreen.InfoScreen = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.InfoScreen);

            // Developer Console
            MainScreen.DeveloperConsole = mainScreen.GetChild((int)MainScreenEnum.DeveloperConsole).gameObject
                .AddComponent<DeveloperConsoleModel>();
            MainScreen.DeveloperConsole.Input = MainScreen.DeveloperConsole.transform.GetChild((int)DeveloperConsoleEnum.Input);
            MainScreen.DeveloperConsole.ScrollView = MainScreen.DeveloperConsole.transform.GetChild((int)DeveloperConsoleEnum.ScrollView);

            // Menu Screen
            MainScreen.MenuScreen = mainScreen.Find($"{MainScreenEnum.MenuScreen}");

            #endregion General
        }

        private void Start()
        {
            BuilderScreenService = MainScreen.BuildScreen.gameObject
                .AddComponent<BuilderScreenService>();
            WindowsMachineService = MainScreen.WindowsMachine.gameObject
                .AddComponent<WindowsMachineService>();
            DeveloperConsoleBehaviour = MainScreen.DeveloperConsole.gameObject
                .GetComponent<DeveloperConsoleBehaviour>();

            BuilderScreenService.Setup(MainScreen.BuildScreen);
            WindowsMachineService.Setup(MainScreen.WindowsMachine);

            _isOpen = false;

            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            Input.Enable();
            Input.BuildMode.ToggleBuildMenu.performed += ToggleBuildMenu;
            Input.UI.EscapeMachineScreen.performed += EscapeMachineScreen;
            Input.UI.ToggleMenuScreen.performed += ToggleMenuScreen;
            Input.Developer.ToggleConsole.performed += ShowDeveloperConsole;
        }

        private void OnDisable()
        {
            Input.Disable();
        }

        private void ToggleMenuScreen(CallbackContext obj)
        {
            if (!MainScreen.MenuScreen.gameObject.activeSelf && !_isOpen)
            {
                _isOpen = true;
                MainScreen.MenuScreen.gameObject.SetActive(true);
            }
            else
            {
                if (MainScreen.MenuScreen.gameObject.activeSelf && _isOpen)
                {
                    _isOpen = false;
                    MainScreen.MenuScreen.gameObject.SetActive(false);
                }
            }
        }

        private void EscapeMachineScreen(CallbackContext context)
        {
            CloseInterfaceMachine();
        }

        private void ShowDeveloperConsole(CallbackContext context)
        {
            if (!context.action.triggered) { return; }

            if (!MainScreen.DeveloperConsole.gameObject.activeSelf && !_isOpen)
            {
                _isOpen = true;

                MainScreen.DeveloperConsole.gameObject.SetActive(true);
                MainScreen.DeveloperConsole.transform.GetChild(0).GetComponent<TMPro.TMP_InputField>().ActivateInputField();
            }
            else
            {
                if (MainScreen.DeveloperConsole.gameObject.activeSelf)
                {
                    MainScreen.DeveloperConsole.gameObject.SetActive(false);
                    _isOpen = false;
                }
            }
        }

        public void UpdateInterfaceMachine(WindowsMachineItemModel windowsMachineItemModel)
        {
            if (MainScreen.WindowsMachine.gameObject.activeSelf)
                WindowsMachineService.UpdateInterfaceMachine(windowsMachineItemModel);
        }

        public void ShowInterfaceMachine()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                MainScreen.WindowsMachine.gameObject.SetActive(true);
            }
        }

        public void CloseInterfaceMachine()
        {
            if (MainScreen.WindowsMachine.gameObject.activeSelf && _isOpen)
            {
                MainScreen.WindowsMachine.gameObject.SetActive(false);
                WindowsMachineService.CloseInterfaceMachine();

                _isOpen = false;
            }
        }

        public void ToggleBuildMenu()
        {
            ToggleBuildMenu(default);
        }

        public void ToggleBuildMenu(InputAction.CallbackContext obj)
        {
            if (!MainScreen.BuildScreen.BuildMenu.gameObject.activeSelf && !_isOpen)
                _isOpen = BuilderScreenService.ToggleBuildMenu(true);

            if (MainScreen.BuildScreen.BuildMenu.gameObject.activeSelf && _isOpen)
                _isOpen = BuilderScreenService.ToggleBuildMenu(false);
        }

        public void ToggleBuildList(int machine)
        {
            BuilderScreenService.ToggleBuildList((CategoryItemEnum)machine);
        }

        public void ItemSelectedToBuild(GameObject gameObject)
        {
            BuilderScreenService.ItemSelectedToBuild(gameObject);
        }

        public void AcceptToBuildMoveTransformSelectedItem()
        {
            BuilderScreenService.AcceptToBuildMoveTransformSelectedItem();
        }

        private void FixedUpdate()
        {
            if (string.IsNullOrEmpty(MainScreen.BottomBar.GetComponentInChildren<Text>().text))
                MainScreen.BottomBar.GetComponentInChildren<Text>().text = VersionIncrementor.version;

            BuilderScreenService.ToggleWindowsBuild();
        }

        public void ToggleInventory()
        {
            throw new NotImplementedException();
        }
    }
}