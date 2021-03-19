using Assets.Script.Enum;
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

        /// <summary>
        /// When the player press B
        /// </summary>
        /// <param name="isBuilding"></param>
        public void ToggleWindowsBuild()
        {
            // BuildMenu
            BuildScreen.gameObject.SetActive(IsBuilding);
            BuildScreen.BuildMenu.gameObject.SetActive(IsBuilding);

            //BuildList
            BuildScreen.BuildList.gameObject.SetActive(IsBuilding && IsReadyToSelect);

            //InfoScreen
            BuildScreen.InfoScreen.gameObject.SetActive(IsBuilding && IsReadyToSelect && IsReadyToAccept);

            KeyCommands();
        }

        private void KeyCommands()
        {
            if (Input.GetKeyDown(KeyCode.B)) IsBuilding = !IsBuilding;

            if (Input.GetKeyDown(KeyCode.Mouse0) && IsBuilding && IsReadyToConstruction)
            {
                // TODO: Remove necessary itens from inventory of player.

                Instantiate(BuildScreen.SelectedItem, GameObject.Find("Map").transform);

                Debug.Log("Clicou");
                IsReadyToConstruction = false;
                IsReadyToAccept = false;
                IsReadyToSelect = false;

                BuildScreen.SelectedItem = null;
            }

            if (Input.GetKeyDown(KeyCode.Escape) && IsBuilding)
            {
                IsReadyToConstruction = false;
                IsReadyToSelect = false;
                IsReadyToAccept = false;
                IsBuilding = false;

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
            Debug.Log("opa");
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