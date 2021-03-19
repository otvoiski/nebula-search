using Assets.Script.Enum;
using Assets.Script.View.Enumerator;
using Assets.Script.View.Model;
using Assets.Script.View.Service;
using System;
using UnityEngine;

namespace Assets.Script.View
{
    public class ViewHandler : MonoBehaviour
    {
        public BuilderScreenService BuilderScreenService { get; private set; }
        public MainScreen MainScreen { get; private set; }
        public bool IsBuilding { get; private set; }
        public bool IsOpen { get; private set; }

        private void Awake()
        {
            #region General

            var mainScreen = GameObject
                .Find("VIEW HANDLER")
                .transform
                .Find("MainScreen");
            MainScreen = mainScreen.gameObject
                .AddComponent<MainScreen>();
            MainScreen.BottomBar = mainScreen.GetChild((int)MainScreenEnum.BottomBar);
            MainScreen.Toast = mainScreen.GetChild((int)MainScreenEnum.Toast);
            MainScreen.InterfaceMenu = mainScreen.GetChild((int)MainScreenEnum.InterfaceMenu).gameObject
                .AddComponent<InterfaceMenu>();
            MainScreen.InterfaceMenu.Title = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Title);
            MainScreen.InterfaceMenu.Inventory = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Inventory);
            MainScreen.InterfaceMenu.IO = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.IO);
            MainScreen.InterfaceMenu.Button = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Button);
            MainScreen.InterfaceMenu.ProcessMenu = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.ProcessMenu);
            MainScreen.InterfaceMenu.Info = MainScreen.InterfaceMenu.transform.GetChild((int)InterfaceMenuEnum.Info);
            MainScreen.BuildScreen = mainScreen.GetChild((int)MainScreenEnum.BuildScreen).gameObject
                .AddComponent<BuildScreen>();
            MainScreen.BuildScreen.BuildMenu = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildMenu);
            MainScreen.BuildScreen.BuildList = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.BuildList);
            MainScreen.BuildScreen.InfoScreen = MainScreen.BuildScreen.transform.GetChild((int)BuildMenuEnum.InfoScreen);

            #endregion General
        }

        private void Start()
        {
            IsOpen = false;

            BuilderScreenService = gameObject.AddComponent<BuilderScreenService>();
            BuilderScreenService.Setup(MainScreen.BuildScreen);
        }

        private void Update()
        {
            Building();
        }

        private void Building()
        {
            if (Input.GetKeyDown(KeyCode.B) && !IsOpen) IsBuilding = !IsBuilding;

            BuilderScreenService.ToggleWindowsBuild(IsBuilding);
        }

        public void ToggleBuildList(int machine)
        {
            BuilderScreenService.ToggleBuildList((MachineEnumerator)machine);
        }

        public void ToggleWindow(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}