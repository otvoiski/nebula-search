using Assets.Data.Enum;
using Assets.Data.Model;
using Assets.Data.Service;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

namespace Assets.Data
{
    public class ViewHandler : MonoBehaviour
    {
        public const string NAME = "VIEW HANDLER";

        public static int LimitTextConsoleItem;
        public WindowsMachineService WindowsMachineService { get; private set; }
        public BuilderScreenService BuilderScreenService { get; private set; }
        public MainScreenModel MainScreen { get; private set; }

        public InputMaster Input;

        public static bool IsOpen;

        private void Awake()
        {
            gameObject.name = NAME;

            LimitTextConsoleItem = 100;

            #region Input

            Input = new InputMaster();
            Input.Menu.ToggleMenuScreen.performed += ToggleMenuScreen;
            Input.Developer.ToggleConsole.performed += ShowDeveloperConsole;

            #endregion Input

            #region General

            var viewHandler = GameObject.Find(NAME)
                .GetComponent<ViewHandler>();

            var mainScreen = viewHandler.transform.Find("MainScreen");

            // Main Screen
            MainScreen = mainScreen.gameObject
                .AddComponent<MainScreenModel>();
            MainScreen.BottomBar = mainScreen.Find($"{MainScreenEnum.BottomBar}");
            MainScreen.Toast = mainScreen.Find($"{MainScreenEnum.Toast}");

            // Windows Machines
            MainScreen.WindowsMachine = mainScreen.Find($"{MainScreenEnum.WindowsMachine}").gameObject
                .AddComponent<WindowsMachineModel>();

            MainScreen.WindowsMachine.Title = MainScreen.WindowsMachine.transform.Find("Screen").Find($"{WindowsMachineEnum.Title}");
            MainScreen.WindowsMachine.Inventory = MainScreen.WindowsMachine.transform.Find("Screen").Find($"{WindowsMachineEnum.Inventory}");
            MainScreen.WindowsMachine.IO = MainScreen.WindowsMachine.transform.Find("Screen").Find($"{WindowsMachineEnum.IO}");
            MainScreen.WindowsMachine.Button = MainScreen.WindowsMachine.transform.Find("Screen").Find($"{WindowsMachineEnum.Button}");
            MainScreen.WindowsMachine.ProcessMenu = MainScreen.WindowsMachine.transform.Find("Screen").Find($"{WindowsMachineEnum.ProcessMenu}");
            MainScreen.WindowsMachine.Info = MainScreen.WindowsMachine.transform.Find("Screen").Find($"{WindowsMachineEnum.Info}");

            // Build Screen
            MainScreen.BuildScreen = mainScreen.Find($"{MainScreenEnum.BuildScreen}").gameObject
                .AddComponent<BuildScreenModel>();
            MainScreen.BuildScreen.BuildMenu = MainScreen.BuildScreen.transform.Find($"{BuildMenuEnum.BuildMenu}");
            MainScreen.BuildScreen.BuildList = MainScreen.BuildScreen.transform.Find($"{BuildMenuEnum.BuildList}");
            MainScreen.BuildScreen.InfoScreen = MainScreen.BuildScreen.transform.Find($"{BuildMenuEnum.InfoScreen}");

            // Developer Console
            MainScreen.DeveloperConsole = mainScreen.Find($"{MainScreenEnum.DeveloperConsole}").gameObject
                .AddComponent<DeveloperConsoleModel>();
            MainScreen.DeveloperConsole.Input = MainScreen.DeveloperConsole.transform.Find($"{DeveloperConsoleEnum.Input}");
            MainScreen.DeveloperConsole.ScrollView = MainScreen.DeveloperConsole.transform.Find($"{DeveloperConsoleEnum.ScrollView}");

            // Menu Screen
            MainScreen.MenuScreen = mainScreen.Find($"{MainScreenEnum.MenuScreen}");

            #endregion General
        }

        private void Start()
        {
            BuilderScreenService = MainScreen.BuildScreen.gameObject
                .GetComponent<BuilderScreenService>();
            WindowsMachineService = MainScreen.WindowsMachine.gameObject
                .GetComponent<WindowsMachineService>();

            BuilderScreenService.Setup(MainScreen.BuildScreen);
            WindowsMachineService.Setup(MainScreen.WindowsMachine);

            IsOpen = false;

            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            Input.Enable();
        }

        private void OnDisable()
        {
            Input.Disable();
        }

        private void FixedUpdate()
        {
            if (string.IsNullOrEmpty(MainScreen.BottomBar.GetComponentInChildren<Text>().text))
                MainScreen.BottomBar.GetComponentInChildren<Text>().text = VersionIncrementor.version;
        }

        private void ToggleMenuScreen(CallbackContext obj)
        {
            if (!MainScreen.MenuScreen.gameObject.activeSelf && !IsOpen)
            {
                IsOpen = true;
                MainScreen.MenuScreen.gameObject.SetActive(true);
            }
            else
            {
                if (MainScreen.MenuScreen.gameObject.activeSelf && IsOpen)
                {
                    IsOpen = false;
                    MainScreen.MenuScreen.gameObject.SetActive(false);
                }
            }
        }

        private void ShowDeveloperConsole(CallbackContext context)
        {
            if (!context.action.triggered) { return; }

            if (!MainScreen.DeveloperConsole.gameObject.activeSelf && !IsOpen)
            {
                IsOpen = true;

                MainScreen.DeveloperConsole.gameObject.SetActive(true);
                MainScreen.DeveloperConsole.transform.GetChild(0).GetComponent<TMPro.TMP_InputField>().ActivateInputField();
            }
            else
            {
                if (MainScreen.DeveloperConsole.gameObject.activeSelf)
                {
                    MainScreen.DeveloperConsole.gameObject.SetActive(false);
                    IsOpen = false;
                }
            }
        }

        public void ToggleInventory()
        {
            throw new NotImplementedException();
        }
    }
}