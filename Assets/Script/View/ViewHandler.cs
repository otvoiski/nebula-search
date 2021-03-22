using Assets.Script.Data.Enum;
using Assets.Script.View.Enumerator;
using Assets.Script.View.Model;
using Assets.Script.View.Service;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Assets.Script.View
{
    public class ViewHandler : MonoBehaviour
    {
        public WindowsMachineService WindowsMachineService { get; private set; }
        public BuilderScreenService BuilderScreenService { get; private set; }
        public MainScreenModel MainScreen { get; private set; }

        private InputMaster _input;

        private void Awake()
        {
            #region Input

            _input = new InputMaster();

            _input.UI.ToggleBuildScreen.performed += ToggleBuildMenu;

            #endregion Input

            #region General

            var viewHandler = GameObject.Find("VIEW HANDLER")
                .GetComponent<ViewHandler>();

            var mainScreen = viewHandler.transform.Find("MainScreen");

            MainScreen = mainScreen.gameObject
                .AddComponent<MainScreenModel>();
            MainScreen.BottomBar = mainScreen.GetChild((int)MainScreenEnum.BottomBar);
            MainScreen.Toast = mainScreen.GetChild((int)MainScreenEnum.Toast);
            MainScreen.WindowsMachine = mainScreen.GetChild((int)MainScreenEnum.WindowsMachine).gameObject
                .AddComponent<WindowsMachineModel>();
            MainScreen.WindowsMachine.Title = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Title);
            MainScreen.WindowsMachine.Inventory = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Inventory);
            MainScreen.WindowsMachine.IO = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.IO);
            MainScreen.WindowsMachine.Button = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Button);
            MainScreen.WindowsMachine.ProcessMenu = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.ProcessMenu);
            MainScreen.WindowsMachine.Info = MainScreen.WindowsMachine.transform.GetChild((int)WindowsMachineEnum.Info);
            MainScreen.BuildScreen = mainScreen.GetChild((int)MainScreenEnum.BuildScreen).gameObject
                .AddComponent<BuildScreenModel>();
            MainScreen.BuildScreen.BuildMenu = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildMenu);
            MainScreen.BuildScreen.BuildList = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildList);
            MainScreen.BuildScreen.InfoScreen = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.InfoScreen);

            #endregion General
        }

        public GameObject GetWindowsMachine()
        {
            return MainScreen.WindowsMachine.gameObject;
        }

        private void Start()
        {
            BuilderScreenService = MainScreen.BuildScreen.gameObject
                .AddComponent<BuilderScreenService>();
            WindowsMachineService = MainScreen.WindowsMachine.gameObject
                .AddComponent<WindowsMachineService>();

            BuilderScreenService.Setup(MainScreen.BuildScreen);
            WindowsMachineService.Setup(MainScreen.WindowsMachine);
        }

        public void CloseInterfaceMachine()
        {
            WindowsMachineService.CloseInterfaceMachine();
        }

        public void ShowInterfaceMachine(WindowsMachineItemModel model)
        {
            WindowsMachineService.ShowInterfaceMachine(model);
        }

        private void Update()
        {
            if (string.IsNullOrEmpty(MainScreen.BottomBar.GetComponentInChildren<Text>().text))
                MainScreen.BottomBar.GetComponentInChildren<Text>().text = VersionIncrementor.version;

            BuilderScreenService.ToggleWindowsBuild();
        }

        public void ToggleBuildMenu(InputAction.CallbackContext obj)
        {
            BuilderScreenService.ToggleBuildMenu();
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

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}