﻿using Assets.Script.Enum;
using Assets.Script.Util;
using Assets.Script.View.Enumerator;
using Assets.Script.View.Model;
using UnityEngine;

namespace Assets.Script.View.Service
{
    public class BuilderScreenService : MonoBehaviour
    {
        public BuildScreenModel BuildScreen { get; private set; }
        public bool IsReadyToSelect { get; private set; }
        public bool IsReadyToAccept { get; private set; }
        public bool IsReadyToConstruction { get; private set; }
        public bool IsBuilding { get; private set; }

        public void Setup(BuildScreenModel buildScreen)
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
            // Open and close windows
            ToggleWindows();

            // Key commands of this interface
            KeyCommands();

            // Movement of transform item when user select item
            Movement();
        }

        private void Movement()
        {
            if (IsBuilding && IsReadyToConstruction && BuildScreen.SelectedItem != null)
            {
                BuildScreen.SelectedItem.transform.position = Utilities.GetPositionGridFromScreenPoint(1);
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

                Instantiate(BuildScreen.SelectedItem, GameObject.Find("Map").transform)
                    .SetActive(true);

                if (BuildScreen.SelectedItem != null && IsReadyToConstruction)
                    Destroy(BuildScreen.SelectedItem);

                BuildScreen.SelectedItem = null;

                IsReadyToConstruction = false;
                IsReadyToAccept = false;
                IsReadyToSelect = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape) && IsBuilding)
            {
                if (BuildScreen.SelectedItem != null && IsReadyToConstruction)
                    Destroy(BuildScreen.SelectedItem);

                BuildScreen.SelectedItem = null;

                IsReadyToConstruction = false;
                IsReadyToSelect = false;
                IsReadyToAccept = false;
                IsBuilding = false;
            }
        }

        /// <summary>
        /// When player click the buton on BuildList
        /// </summary>
        /// <param name="gameObject"></param>
        public void AcceptToBuildMoveTransformSelectedItem()
        {
            BuildScreen.SelectedItem = Instantiate(BuildScreen.SelectedItem, GameObject.Find("GAME HANDLER").transform);
            BuildScreen.SelectedItem.SetActive(true);

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

            pipeList.gameObject.SetActive(false);
            generatorList.gameObject.SetActive(false);
            machineList.gameObject.SetActive(false);

            switch (enumerator)
            {
                case MachineEnumerator.Generator:
                    generatorList.gameObject.SetActive(true);
                    break;

                case MachineEnumerator.Machine:
                    machineList.gameObject.SetActive(true);
                    break;

                case MachineEnumerator.Pipe:
                    pipeList.gameObject.SetActive(true);
                    break;

                default:
                    break;
            }

            IsReadyToSelect = !IsReadyToSelect;
            IsReadyToAccept = false;
        }
    }
}