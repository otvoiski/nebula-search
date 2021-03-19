using Assets.Script.Enum;
using Assets.Script.View.Enumerator;
using Assets.Script.View.Model;
using System;
using UnityEngine;

namespace Assets.Script.View.Service
{
    public class BuilderScreenService : MonoBehaviour
    {
        public void Setup(BuildScreen buildScreen)
        {
            BuildScreen = buildScreen;
            IsReadyForSelectItem = false;
            IsReadyForConstruction = false;
        }

        public BuildScreen BuildScreen { get; private set; }
        public bool IsReadyForSelectItem { get; private set; }
        public bool IsReadyForConstruction { get; private set; }

        /// <summary>
        /// When player click the buton on BuildList
        /// </summary>
        /// <param name="gameObject"></param>
        public void PutObjectInTheWorld(GameObject gameObject)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                IsReadyForConstruction = false;

                // TODO: Remove necessary itens from inventory of player.
                Instantiate(gameObject, GameObject.Find("Map").transform);
            }
        }

        public void CreateItemInWorld(GameObject gameObject)
        {
            BuildScreen.SelectedItem = Instantiate(gameObject, this.gameObject.transform);
            BuildScreen.SelectedItem.SetActive(true);
        }

        public void ToggleWindowsBuild(bool isBuilding)
        {
            BuildScreen.gameObject.SetActive(isBuilding);
            BuildScreen.BuildMenu.gameObject.SetActive(isBuilding);
            //BuildScreen.BuildList.gameObject.SetActive(IsReadyForSelectItem);
            //BuildScreen.InfoScreen.gameObject.SetActive(IsReadyForSelectItem);
        }

        public void ToggleBuildList(MachineEnumerator enumerator)
        {
            var generatorList = BuildScreen.BuildList.transform.GetChild((int)BuildListEnum.GeneratorList);
            var machineList = BuildScreen.BuildList.transform.GetChild((int)BuildListEnum.MachineList);
            var pipeList = BuildScreen.BuildList.transform.GetChild((int)BuildListEnum.PipeList);

            IsReadyForSelectItem = !IsReadyForSelectItem;
            switch (enumerator)
            {
                case MachineEnumerator.Generator:
                    generatorList.gameObject.SetActive(IsReadyForSelectItem);

                    machineList.gameObject.SetActive(false);
                    pipeList.gameObject.SetActive(false);
                    break;

                case MachineEnumerator.Machine:
                    machineList.gameObject.SetActive(IsReadyForSelectItem);

                    pipeList.gameObject.SetActive(false);
                    generatorList.gameObject.SetActive(false);
                    break;

                case MachineEnumerator.Pipe:
                    pipeList.gameObject.SetActive(IsReadyForSelectItem);

                    machineList.gameObject.SetActive(false);
                    generatorList.gameObject.SetActive(false);
                    break;

                default:
                    break;
            }

            BuildScreen.BuildList.gameObject.SetActive(IsReadyForSelectItem);
            BuildScreen.InfoScreen.gameObject.SetActive(IsReadyForSelectItem);
        }
    }
}