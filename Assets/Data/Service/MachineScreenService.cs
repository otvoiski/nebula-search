using Assets.Data.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Data.Service
{
    public class MachineScreenService : MonoBehaviour
    {
        public bool IsOpen;

        private InputMaster _input;
        private Transform _panel;
        private MachineService _machine;

        private void OnEnable()
        {
            _input.MachineScreen.Enable();
        }

        private void OnDisable()
        {
            _input.MachineScreen.Disable();
        }

        private void Awake()
        {
            _input = new InputMaster();

            _input.MachineScreen.OpenMachineScreen.performed += _ => OpenScreen();
            _input.MachineScreen.EscapeMachineScreen.performed += _ => CloseScreen();

            // Map Panel
            _panel = transform.Find("Panel");

            // Map Button
            _panel.Find("Buttons").Find("Close").GetComponentInChildren<Button>().onClick.AddListener(CloseScreen);
        }

        private void Update()
        {
            IsOpen = ViewHandler.IsOpen;

            if (_machine != null)
            {
                UpdateScreen(_machine);
            }
        }

        private void UpdateScreen(MachineService machine)
        {
            // Update Title
            _panel.Find("Title").Find("Text").GetComponent<TextMeshProUGUI>().text = machine.Type.Title;

            // Update Information
            _panel.Find("Information").Find("Energy").GetComponentInChildren<TextMeshProUGUI>()
                .text = $"{machine.Buffer}/{machine.Type.MaxBuffer}";

            var power = _panel.Find("Information").Find("Power").GetComponentInChildren<TextMeshProUGUI>();
            if (machine.Type.Power > 0)
            {
                power.text = $"+{machine.Type.Power}μ";
                power.color = Color.green;
            }
            else
            {
                power.text = $"-{machine.Type.Power}μ";
                power.color = Color.red;
            }

            _panel.Find("Information").Find("ProcessTime").GetComponentInChildren<TextMeshProUGUI>()
                .text = $"{machine.ProcessTime}/{machine.Type.MaxProcessTime}";

            // Process Sliders
            var energy = _panel.Find("Process").Find("Energy").GetComponentInChildren<Slider>();
            energy.maxValue = machine.Type.MaxBuffer;
            energy.value = machine.Buffer;

            var process = _panel.Find("Process").Find("ProcessTime").GetComponentInChildren<Slider>();
            process.maxValue = machine.Type.MaxProcessTime;
            process.value = machine.ProcessTime;
        }

        private void OpenScreen()
        {
            // Get Component in parent, because the collider is in the child.
            var machine = Utilities.GetGameObjectFromMousePosition()
                .GetComponentInParent<MachineService>();

            if (!_panel.gameObject.activeSelf && !ViewHandler.IsOpen && machine != null)
            {
                _machine = machine;

                _panel.gameObject.SetActive(true);

                ViewHandler.IsOpen = true;
            }
        }

        private void CloseScreen()
        {
            if (_panel.gameObject.activeSelf && ViewHandler.IsOpen)
            {
                _panel.gameObject.SetActive(false);
                ViewHandler.IsOpen = false;
            }
        }
    }
}