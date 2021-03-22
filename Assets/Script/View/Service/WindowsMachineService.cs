﻿using Assets.Script.View.Model;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.View.Service
{
    public class WindowsMachineService : MonoBehaviour
    {
        private WindowsMachineModel windowsMachine;
        private GameObject defaultImageInputOuput;
        private static WindowsMachineItemModel windowsMachineItemModelStatic;
        private bool isShowInfo;
        private const string CLOSE_BUTTON = "Close";
        private const string INFO_BUTTON = "Info";
        private const string PROCESS_ITEM_ENERGY = "Process Item - Energy";
        private const string PROCESS_ITEM_TIMER = "Process Item - Time Process";
        private const string TITLE_TEXT = "Text";

        public void Setup(WindowsMachineModel windowsMachine)
        {
            this.windowsMachine = windowsMachine;
            defaultImageInputOuput = Resources.Load<GameObject>("Prefabs/UI/MainScreen/WindowsMachine/IO/DefaultImageInputOuput");
            SetupButtons();
        }

        private void SetupButtons()
        {
            var closeButton = windowsMachine.Title.Find(CLOSE_BUTTON).GetComponent<Button>();
            var infoButton = windowsMachine.Button.Find(INFO_BUTTON).GetComponent<Button>();

            closeButton.GetComponent<Button>().onClick.AddListener(delegate { CloseInterfaceMachine(); });
            infoButton.GetComponent<Button>().onClick.AddListener(delegate { ShowInfoMachine(); });
        }

        private void ShowInfoMachine()
        {
            if (windowsMachineItemModelStatic != null)
                isShowInfo = !isShowInfo;
        }

        public void CloseInterfaceMachine()
        {
            Debug.Log("Close");

            windowsMachine.gameObject.SetActive(false);
        }

        public void ShowInterfaceMachine(WindowsMachineItemModel model)
        {
            windowsMachineItemModelStatic = model;

            ChangeTitle();
            LoadProcess();
            LoadIO();
            LoadInventory();
            LoadInfo();

            windowsMachine.gameObject.SetActive(true);
        }

        private void ChangeTitle()
        {
            windowsMachine.Title.Find(TITLE_TEXT) // Text
                .GetComponent<Text>().text = windowsMachineItemModelStatic.title;
        }

        private void LoadProcess()
        {
            var energy = windowsMachine.ProcessMenu.Find(PROCESS_ITEM_ENERGY) // Text
               .GetComponentInChildren<Slider>();

            var timer = windowsMachine.ProcessMenu.Find(PROCESS_ITEM_TIMER)
               .GetComponentInChildren<Slider>();

            energy.maxValue = windowsMachineItemModelStatic.maxBuffer;
            energy.value = windowsMachineItemModelStatic.buffer;

            timer.maxValue = windowsMachineItemModelStatic.maxProcessTime;
            timer.value = windowsMachineItemModelStatic.processTime;
        }

        private void LoadIO()
        {
            var input = windowsMachine.IO.Find("Input");
            if (input.childCount == 0)
            {
                for (int i = 0; i < windowsMachineItemModelStatic.InputAmount; i++)
                {
                    Instantiate(defaultImageInputOuput, input.transform).name = i.ToString();
                }
            }
            var output = windowsMachine.IO.Find("Output");
            if (output.childCount == 0)
            {
                for (int i = 0; i < windowsMachineItemModelStatic.OutputAmount; i++)
                {
                    Instantiate(defaultImageInputOuput, output.transform).name = i.ToString();
                }
            }
        }

        private void LoadInventory()
        {
        }

        private void LoadInfo()
        {
            if (windowsMachineItemModelStatic != null)
            {
                var energy = windowsMachine.Info.Find("Energy");
                var timer = windowsMachine.Info.Find("ProcessTime");
                var consume = windowsMachine.Info.Find("PowerConsume");

                //TODO: Continue to fill

                Change(energy, "Energy", $"{windowsMachineItemModelStatic.buffer}/{windowsMachineItemModelStatic.maxBuffer}");

                void Change(Transform transform, string title, string value)
                {
                    transform.Find("Title").GetComponent<Text>().text = title;
                    transform.Find("Value").GetComponent<Text>().text = value;
                }
            }

            windowsMachine.Info.gameObject.SetActive(isShowInfo);
        }
    }
}