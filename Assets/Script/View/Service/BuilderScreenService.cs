using Assets.Script.Enum;
using Assets.Script.Util;
using Assets.Script.View.Enumerator;
using Assets.Script.View.Model;
using UnityEngine;

namespace Assets.Script.View.Service
{
    public class BuilderScreenService : MonoBehaviour
    {
        public BuildScreen BuildScreen { get; private set; }
        public bool IsReadyToSelect { get; private set; }
        public bool IsReadyToAccept { get; private set; }
        public bool IsReadyToConstruction { get; private set; }
        public bool IsBuilding { get; private set; }

        public void Setup(BuildScreen buildScreen)
        {
            BuildScreen = buildScreen;

            IsReadyToAccept = false;
            IsReadyToConstruction = false;
            IsReadyToSelect = false;
            IsBuilding = false;
        }

        public void Update()
        {
            if (IsBuilding && IsReadyToConstruction && BuildScreen.SelectedItem != null)
            {
                var ray = Utilities.GetPositionGridFromScreenPoint(1);

                BuildScreen.SelectedItem.transform.position = ray;
            }
        }

        /// <summary>
        /// When the player press B
        /// </summary>
        /// <param name="isBuilding"></param>
        public void ToggleWindowsBuild()
        {
            // Open and close windows
            ToggleWindows();

            // Key commands of this interface
            KeyCommands();

            // Movement of transform item when user select item
            //Movement();
        }

        private void Movement()
        {
            if (IsBuilding && IsReadyToConstruction && BuildScreen.SelectedItem != null)
            {
                var ray = Utilities.GetPositionGridFromScreenPoint(0);

                BuildScreen.SelectedItem.transform.position = ray;

                //var ray = Utilities.GetRaycastHitFromScreenPoint();
                //if (ray.HasValue)
                //    BuildScreen.SelectedItem.transform.position = ray
                //        .GetValueOrDefault()
                //        .transform
                //        .position;
            }
        }

        private void ToggleWindows()
        {
            // BuildMenu
            BuildScreen.gameObject.SetActive(IsBuilding);
            BuildScreen.BuildMenu.gameObject.SetActive(IsBuilding);

            //BuildList
            BuildScreen.BuildList.gameObject.SetActive(IsBuilding && IsReadyToSelect);

            //InfoScreen
            BuildScreen.InfoScreen.gameObject.SetActive(IsBuilding && IsReadyToSelect && IsReadyToAccept);
        }

        private void KeyCommands()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                IsBuilding = !IsBuilding;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && IsBuilding && IsReadyToConstruction)
            {
                // TODO: Remove necessary itens from inventory of player.

                var item = Instantiate(BuildScreen.SelectedItem, GameObject.Find("Map").transform);
                item.SetActive(true);

                Debug.Log("Clicou");
                IsReadyToConstruction = false;
                IsReadyToAccept = false;
                IsReadyToSelect = false;
                BuildScreen.SelectedItem = null;
                if (BuildScreen.SelectedItem != null)
                    Destroy(BuildScreen.SelectedItem);
            }

            if (Input.GetKeyDown(KeyCode.Escape) && IsBuilding)
            {
                IsReadyToConstruction = false;
                IsReadyToSelect = false;
                IsReadyToAccept = false;
                IsBuilding = false;

                if (BuildScreen.SelectedItem != null)
                    Destroy(BuildScreen.SelectedItem);
                BuildScreen.SelectedItem = null;

                Debug.Log("bye");
            }
        }

        /// <summary>
        /// When player click the buton on BuildList
        /// </summary>
        /// <param name="gameObject"></param>
        public void AcceptToBuildMoveTransformSelectedItem()
        {
            var item = Instantiate(BuildScreen.SelectedItem, GameObject.Find("GAME HANDLER").transform);
            item.SetActive(true);

            IsReadyToConstruction = true;
            IsReadyToSelect = false;
            IsReadyToAccept = false;
        }

        /// <summary>
        /// Create item in world later user accept to created
        /// </summary>
        /// <param name="gameObject"></param>
        public void ItemSelectedToBuild(GameObject gameObject)
        {
            IsReadyToAccept = !IsReadyToAccept;
            BuildScreen.SelectedItem = gameObject;
        }

        /// <summary>
        /// Update screen to build list
        /// </summary>
        /// <param name="enumerator"></param>
        public void ToggleBuildList(MachineEnumerator enumerator)
        {
            var generatorList = BuildScreen.BuildList.transform.GetChild((int)BuildListEnum.GeneratorList);
            var machineList = BuildScreen.BuildList.transform.GetChild((int)BuildListEnum.MachineList);
            var pipeList = BuildScreen.BuildList.transform.GetChild((int)BuildListEnum.PipeList);

            switch (enumerator)
            {
                case MachineEnumerator.Generator:
                    generatorList.gameObject.SetActive(true);

                    machineList.gameObject.SetActive(false);
                    pipeList.gameObject.SetActive(false);
                    break;

                case MachineEnumerator.Machine:
                    machineList.gameObject.SetActive(true);

                    pipeList.gameObject.SetActive(false);
                    generatorList.gameObject.SetActive(false);
                    break;

                case MachineEnumerator.Pipe:
                    pipeList.gameObject.SetActive(true);

                    machineList.gameObject.SetActive(false);
                    generatorList.gameObject.SetActive(false);
                    break;

                default:
                    break;
            }

            IsReadyToSelect = !IsReadyToSelect;
        }
    }
}