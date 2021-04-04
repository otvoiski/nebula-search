using Assets.Data.Model;
using Assets.Data.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Data.Service
{
    public class WindowsMachineService : MonoBehaviour
    {
        public bool IsOpen;

        private WindowsMachineModel _windowsMachine;
        private GameObject _defaultImageInputOutput;
        private static WindowsMachineItemModel _windowsMachineItemModelStatic;
        private bool _isShowInfo;
        private const string ProcessItemEnergy = "Process Item - Energy";
        private const string ProcessItemTimer = "Process Item - Time Process";

        public void Setup(WindowsMachineModel windowsMachine)
        {
            _windowsMachine = windowsMachine;
            _defaultImageInputOutput = Resources.Load<GameObject>("Prefabs/UI/MainScreen/WindowsMachine/IO/DefaultImageInputOutput");
            var closeButton = _windowsMachine.transform.Find("Screen").Find("Title").Find("Close").GetComponent<Button>();
            var infoButton = _windowsMachine.transform.Find("Screen").Find("Button").Find("Info").GetComponent<Button>();

            closeButton.onClick.AddListener(CloseInterfaceMachine);
            infoButton.onClick.AddListener(ShowInfoMachine);
        }

        public void Update()
        {
            IsOpen = ViewHandler.IsOpen;
        }

        public bool OpenMachineScreen(WindowsMachineItemModel windowsMachineItemModel)
        {
            _windowsMachineItemModelStatic = windowsMachineItemModel;

            if (!_windowsMachine.transform.Find("Screen").gameObject.activeSelf && !ViewHandler.IsOpen)
            {
                _windowsMachine.transform.Find("Screen").gameObject.SetActive(true);

                ChangeTitle();
                LoadProcess();
                LoadInputOutput();
                LoadInventory();
                LoadInfo();

                ViewHandler.IsOpen = true;

                return true;
            }

            return false;
        }

        public void CloseInterfaceMachine()
        {
            if (_windowsMachine.transform.Find("Screen").gameObject.activeSelf && ViewHandler.IsOpen)
            {
                _windowsMachine.transform.Find("Screen").gameObject.SetActive(false);
                _windowsMachineItemModelStatic = null;

                ChangeTitleReset();
                LoadProcessReset();
                LoadInputOutputReset();
                LoadInventoryReset();
                LoadInfoReset();

                ViewHandler.IsOpen = false;
            }
        }

        public void ShowInfoMachine()
        {
            if (_windowsMachineItemModelStatic != null)
                _isShowInfo = !_isShowInfo;
        }

        public void UpdateInterfaceMachine(WindowsMachineItemModel model)
        {
            _windowsMachineItemModelStatic = model;
            if (_windowsMachineItemModelStatic != null)
            {
                ChangeTitle();
                LoadProcess();
                LoadInputOutput();
                LoadInventory();
                LoadInfo();
            }
        }

        private void ChangeTitle()
        {
            _windowsMachine.transform.Find("Screen").Find("Title").Find("Text") // Text
                .GetComponent<Text>().text = _windowsMachineItemModelStatic?.title;
        }

        private void ChangeTitleReset()
        {
            _windowsMachine.transform.Find("Screen").Find("Title").Find("Text")
                .GetComponent<Text>().text = "";
        }

        private void LoadProcess()
        {
            var energy = _windowsMachine.ProcessMenu.Find(ProcessItemEnergy) // Text
               .GetComponentInChildren<Slider>();

            var timer = _windowsMachine.ProcessMenu.Find(ProcessItemTimer)
               .GetComponentInChildren<Slider>();

            energy.maxValue = _windowsMachineItemModelStatic.maxBuffer;
            energy.value = _windowsMachineItemModelStatic.buffer;

            timer.maxValue = _windowsMachineItemModelStatic.maxProcessTime;
            timer.value = _windowsMachineItemModelStatic.processTime;
        }

        private void LoadProcessReset()
        {
            var energy = _windowsMachine.ProcessMenu.Find(ProcessItemEnergy) // Text
               .GetComponentInChildren<Slider>();

            var timer = _windowsMachine.ProcessMenu.Find(ProcessItemTimer)
               .GetComponentInChildren<Slider>();

            energy.maxValue = 1;
            energy.value = 0;

            timer.maxValue = 1;
            timer.value = 0;
        }

        private void LoadInputOutput()
        {
            var input = _windowsMachine.IO.Find("Input");
            if (input.childCount == 0)
            {
                for (int i = 0; i < _windowsMachineItemModelStatic.InputAmount; i++)
                {
                    Instantiate(_defaultImageInputOutput, input.transform).name = i.ToString();
                }
            }
            var output = _windowsMachine.IO.Find("Output");
            if (output.childCount == 0)
            {
                for (int i = 0; i < _windowsMachineItemModelStatic.OutputAmount; i++)
                {
                    Instantiate(_defaultImageInputOutput, output.transform).name = i.ToString();
                }
            }
        }

        private void LoadInputOutputReset()
        {
            foreach (Transform child in _windowsMachine.IO.Find("Input"))
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in _windowsMachine.IO.Find("Output"))
            {
                Destroy(child.gameObject);
            }
        }

        private void LoadInventory()
        {
        }

        private void LoadInventoryReset()
        {
        }

        private void LoadInfo()
        {
            if (_windowsMachineItemModelStatic != null)
            {
                var energy = _windowsMachine.Info.Find("Energy");
                var timer = _windowsMachine.Info.Find("ProcessTime");
                var consume = _windowsMachine.Info.Find("Power");

                Change(energy, Locale.Translate["WindowsMachine"]["Energy"], $"{ _windowsMachineItemModelStatic.buffer}/{_windowsMachineItemModelStatic.maxBuffer}");
                Change(timer, Locale.Translate["WindowsMachine"]["ProcessTime"], $"{ _windowsMachineItemModelStatic.processTime}/{_windowsMachineItemModelStatic.maxProcessTime}");
                Change(consume, Locale.Translate["WindowsMachine"]["Power"], $"{ _windowsMachineItemModelStatic.Power}");

                void Change(Transform t, string title, string value)
                {
                    t.Find("Title").GetComponentInChildren<Text>().text = title;
                    t.Find("Value").GetComponentInChildren<Text>().text = value;
                }
            }

            _windowsMachine.Info.gameObject.SetActive(_isShowInfo);
        }

        private void LoadInfoReset()
        {
            if (_windowsMachineItemModelStatic != null)
            {
                var energy = _windowsMachine.Info.Find("Energy");
                var timer = _windowsMachine.Info.Find("ProcessTime");
                var consume = _windowsMachine.Info.Find("Power");

                Change(energy);
                Change(timer);
                Change(consume);

                void Change(Transform t)
                {
                    t.Find("Title").GetComponent<Text>().text = string.Empty;
                    t.Find("Value").GetComponent<Text>().text = string.Empty;
                }
            }

            _windowsMachine.Info.gameObject.SetActive(_isShowInfo);
        }
    }
}