using Assets.Script.Data.Enum;
using Assets.Script.View.Enumerator;
using Assets.Script.View.Model;
using Assets.Script.View.Service;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Assets.Script.View
{
    public class ViewHandler : MonoBehaviour
    {
        public BuilderScreenService BuilderScreenService { get; private set; }
        public MainScreenModel MainScreen { get; private set; }
        public bool IsOpen { get; private set; }

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
            MainScreen.InterfaceMenu = mainScreen.GetChild((int)MainScreenEnum.InterfaceMenu).gameObject
                .AddComponent<InterfaceMenuModel>();
            MainScreen.InterfaceMenu.Title = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Title);
            MainScreen.InterfaceMenu.Inventory = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Inventory);
            MainScreen.InterfaceMenu.IO = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.IO);
            MainScreen.InterfaceMenu.Button = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Button);
            MainScreen.InterfaceMenu.ProcessMenu = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.ProcessMenu);
            MainScreen.InterfaceMenu.Info = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Info);
            MainScreen.BuildScreen = mainScreen.GetChild((int)MainScreenEnum.BuildScreen).gameObject
                .AddComponent<BuildScreenModel>();
            MainScreen.BuildScreen.BuildMenu = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildMenu);
            MainScreen.BuildScreen.BuildList = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildList);
            MainScreen.BuildScreen.InfoScreen = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.InfoScreen);

            #endregion General
        }

        private void Start()
        {
            IsOpen = false;

            BuilderScreenService = MainScreen.BuildScreen.gameObject
                .AddComponent<BuilderScreenService>();

            BuilderScreenService.Setup(MainScreen.BuildScreen);
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