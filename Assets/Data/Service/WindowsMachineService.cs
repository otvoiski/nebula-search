using Assets.Data.Model;
using Assets.Data.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Data.Service
{
    public class WindowsMachineService : MonoBehaviour
    {
        private WindowsMachineModel _windowsMachine;
        private GameObject _defaultImageInputOuput;
        private static WindowsMachineItemModel _windowsMachineItemModelStatic;
        private bool _isShowInfo;
        private const string CloseButton = "Close";
        private const string InfoButton = "Info";
        private const string ProcessItemEnergy = "Process Item - Energy";
        private const string ProcessItemTimer = "Process Item - Time Process";
        private const string TitleText = "Text";

        public void Setup(WindowsMachineModel windowsMachine)
        {
            this._windowsMachine = windowsMachine;
            _defaultImageInputOuput = Resources.Load<GameObject>("Prefabs/UI/MainScreen/WindowsMachine/IO/DefaultImageInputOuput");
            SetupButtons();
        }

        private void SetupButtons()
        {
            var closeButton = _windowsMachine.Title.Find(CloseButton).GetComponent<Button>();
            var infoButton = _windowsMachine.Button.Find(InfoButton).GetComponent<Button>();

            closeButton.GetComponent<Button>().onClick.AddListener(delegate
            {
                GameObject.Find("VIEW HANDLER").GetComponent<ViewHandler>().CloseInterfaceMachine();
            });
            infoButton.GetComponent<Button>().onClick.AddListener(ShowInfoMachine);
        }

        private void ShowInfoMachine()
        {
            if (_windowsMachineItemModelStatic != null)
                _isShowInfo = !_isShowInfo;
        }

        public void CloseInterfaceMachine()
        {
            _windowsMachineItemModelStatic = null;

            ChangeTitleReset();
            LoadProcessReset();
            LoadIOReset();
            LoadInventoryReset();
            LoadInfoReset();
        }

        public void UpdateInterfaceMachine(WindowsMachineItemModel model)
        {
            _windowsMachineItemModelStatic = model;
            if (_windowsMachineItemModelStatic != null)
            {
                ChangeTitle();
                LoadProcess();
                LoadIO();
                LoadInventory();
                LoadInfo();
            }
        }

        private void ChangeTitle()
        {
            _windowsMachine.Title.Find(TitleText) // Text
                .GetComponent<Text>().text = _windowsMachineItemModelStatic.title;
        }

        private void ChangeTitleReset()
        {
            _windowsMachine.Title.Find(TitleText) // Text
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

        private void LoadIO()
        {
            var input = _windowsMachine.IO.Find("Input");
            if (input.childCount == 0)
            {
                for (int i = 0; i < _windowsMachineItemModelStatic.InputAmount; i++)
                {
                    Instantiate(_defaultImageInputOuput, input.transform).name = i.ToString();
                }
            }
            var output = _windowsMachine.IO.Find("Output");
            if (output.childCount == 0)
            {
                for (int i = 0; i < _windowsMachineItemModelStatic.OutputAmount; i++)
                {
                    Instantiate(_defaultImageInputOuput, output.transform).name = i.ToString();
                }
            }
        }

        private void LoadIOReset()
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

                void Change(Transform transform, string title, string value)
                {
                    transform.Find("Title").GetComponent<Text>().text = title;
                    transform.Find("Value").GetComponent<Text>().text = value;
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

                void Change(Transform transform)
                {
                    transform.Find("Title").GetComponent<Text>().text = string.Empty;
                    transform.Find("Value").GetComponent<Text>().text = string.Empty;
                }
            }

            _windowsMachine.Info.gameObject.SetActive(_isShowInfo);
        }
    }
}