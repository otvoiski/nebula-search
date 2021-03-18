using Assets.Script.Enum;
using Assets.Script.View.Enumerator;
using Assets.Script.View.Model;
using UnityEngine;

namespace Assets.Script.View
{
    public class ViewHandler : MonoBehaviour
    {
        public MainScreen MainScreen { get; private set; }
        public bool IsOpen { get; private set; }

        private void Awake()
        {
            #region General

            var mainScreen = GameObject
                .Find("UI")
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
        }

        public void ToggleBuildList(MachineEnumerator enumerator)
        {
            var generalList = MainScreen.BuildScreen.transform.GetChild((int)BuildListEnum.GeneratorList);
            var machineList = MainScreen.BuildScreen.transform.GetChild((int)BuildListEnum.MachineList);
            var pipeList = MainScreen.BuildScreen.transform.GetChild((int)BuildListEnum.PipeList);

            switch (enumerator)
            {
                case MachineEnumerator.Generator:
                    generalList.gameObject.SetActive(generalList.gameObject.activeSelf);
                    break;

                case MachineEnumerator.Machine:
                    machineList.gameObject.SetActive(machineList.gameObject.activeSelf);
                    break;

                case MachineEnumerator.Pipe:
                    pipeList.gameObject.SetActive(pipeList.gameObject.activeSelf);
                    break;

                default:
                    break;
            }
        }

        public void CreateItemInWorld(GameObject gameObject)
        {
            MainScreen.BuildScreen.SelectedItem = Instantiate(gameObject, this.gameObject.transform);
            MainScreen.BuildScreen.SelectedItem.SetActive(true);
        }

        public void ToggleWindowsBuild(bool isBuilding)
        {
            // TODO: If client press V reset mouse selectedItem
            // TODO: Open build screen
            // TODO: If client click um item from build screen open listItemBuild
            // TODO: If client pass mouse in item show infoScreenBuild
            // TODO: If client click close all screen exceto buildScreen and change icon

            //var button = gameObject.GetComponent<Button>();
            //button.onClick.AddListener(delegate { CreateItemInWorld(gameObject); });

            if (isBuilding)
            {
                // Moved mouse with item
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 15f))
                {
                    if (MainScreen.BuildScreen.SelectedItem != null)
                    {
                        MainScreen.BuildScreen.SelectedItem.transform.position = new Vector3(
                        Mathf.CeilToInt(hit.point.x),
                        0,
                        Mathf.CeilToInt(hit.point.z));
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        //TODO: Check if have itens on inventory
                        // Inventory

                        if (MainScreen.BuildScreen.SelectedItem != null)
                            Instantiate(MainScreen.BuildScreen.SelectedItem);
                    }
                }
            }
            else
            {
                if (MainScreen.BuildScreen.SelectedItem != null)
                {
                    MainScreen.BuildScreen.SelectedItem.SetActive(isBuilding);
                    Destroy(MainScreen.BuildScreen.SelectedItem);
                    MainScreen.BuildScreen.SelectedItem = null;
                }
            }

            MainScreen.BuildScreen.gameObject.SetActive(isBuilding);
        }

        public void ToggleWindow(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}