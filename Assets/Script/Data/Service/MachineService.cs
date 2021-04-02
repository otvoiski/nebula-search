using Assets.Script.Enumerator;
using Assets.Script.Util;
using Assets.Script.View;
using Assets.Script.View.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Data.Service
{
    public class MachineService : MonoBehaviour
    {
        public const float CONNECTION = 1.5f;

        public MachineModel Type;

        public string Title { get; private set; }
        public int MaxBuffer { get; private set; }
        public int PowerConsume { get; private set; }
        public int Buffer { get; private set; }
        public int MaxProcessTime { get; private set; }
        public int ProcessTime { get; private set; }
        public IList<Material> Outputs { get; private set; }
        public IList<Material> Inputs { get; private set; }

        private SpriteRenderer _sprite;
        private IList<GasService> _gases;
        private IList<WireService> _wires;
        private bool _isNecessaryEnergy;
        private bool _isNecessaryOxygen;

        private float _oneSecondProcessTimerRunner;
        private float _maxProcessTimeRunner;
        private ViewHandler _viewHandler;
        private InputMaster _input;

        private void Awake()
        {
            _input = new InputMaster();
            _input.MachineScreen.ClickMachine.performed += _ => MachineInterface();

            _viewHandler = GameObject.Find("VIEW HANDLER")
                .GetComponent<ViewHandler>();
        }

        private void Enable()
        {
            _input.MachineScreen.Enable();
        }

        private void Disable()
        {
            _input.MachineScreen.Disable();
        }

        public void Start()
        {
            _sprite = GetComponentInChildren<SpriteRenderer>();

            if (Type != null)
            {
                name = Type.title;
                Title = Type.title;

                MaxBuffer = Type.maxBuffer;
                PowerConsume = Type.powerConsume;
                MaxProcessTime = Type.maxProcessTime;
                Outputs = Type.outputs;
                Inputs = Type.inputs;

                Buffer = 0;
                _isNecessaryEnergy = Inputs.Contains(Material.Energy);
                _isNecessaryOxygen = Inputs.Contains(Material.Oxygen);
            }
        }

        public void Update()
        {
            if (_viewHandler.MainScreen.WindowsMachine.gameObject.activeSelf)
                _viewHandler.WindowsMachineService.UpdateInterfaceMachine(new WindowsMachineItemModel
                {
                    buffer = Buffer,
                    maxBuffer = MaxBuffer,
                    maxProcessTime = MaxProcessTime,
                    powerGenerator = PowerConsume,
                    processTime = ProcessTime,
                    title = Title,
                    InputAmount = Inputs.Count,
                    OutputAmount = Outputs.Count
                });
        }

        private void FixedUpdate()
        {
            if (Buffer < 0) Buffer = 0;
            if (Buffer > MaxBuffer) Buffer = MaxBuffer;

            if (TimerRun.Run(1f, ref _oneSecondProcessTimerRunner))
            {
                if (Buffer >= PowerConsume)
                    ProcessTime++;

                if (_isNecessaryEnergy)
                {
                    ConnectionToWire();
                }

                if (_isNecessaryOxygen)
                {
                    ConnectionToGas();
                }
            }

            if (TimerRun.Run(MaxProcessTime, ref _maxProcessTimeRunner) && Buffer >= PowerConsume)
            {
                Buffer -= PowerConsume;
                ProcessTime = 0;
            }

            SpriteColor();
        }

        private void MachineInterface()
        {
            var ray = Utilities.GetMousePositionInRaycastHit();
            if (ray.HasValue)
            {
                if (ray.GetValueOrDefault().collider.name.Contains(Title))
                {
                    Debug.Log($"Machine Name: {ray.GetValueOrDefault().collider.name}");
                    if (!ViewHandler.IsOpen)
                    {
                        _viewHandler.MainScreen.WindowsMachine.gameObject.SetActive(true);
                        ViewHandler.IsOpen = true;
                    }
                }
            }
        }

        private bool VerifyPathToEnergyGenerator(WireService wire, List<string> list)
        {
            var nextWire = wire.Next(last: list);
            if (nextWire != null)
            {
                var result = VerifyPathToEnergyGenerator(nextWire, list);
                nextWire.SpriteColor(result);
                return result;
            }
            else if (Utilities.GetItemsFromRayCast<GeneratorService>(wire.transform, CONNECTION).Count != 0)
            {
                foreach (var generator in Utilities.GetItemsFromRayCast<GeneratorService>(wire.transform, CONNECTION))
                {
                    if (Inputs.Contains(generator.Output) && Buffer < MaxBuffer)
                        Buffer += generator.GetBufferFromRate(PowerConsume);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VerifyPathToEnergyGenerator(GasService gas, List<string> list)
        {
            var nextGas = gas.Next(last: list);
            if (nextGas != null)
            {
                var result = VerifyPathToEnergyGenerator(nextGas, list);
                nextGas.SpriteColor(result);
                return result;
            }
            else if (Utilities.GetItemsFromRayCast<GeneratorService>(gas.transform, CONNECTION).Count != 0)
            {
                foreach (var generator in Utilities.GetItemsFromRayCast<GeneratorService>(gas.transform, CONNECTION))
                {
                    if (Inputs.Contains(generator.Output))
                        Buffer += generator.GetBufferFromRate(PowerConsume);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ConnectionToWire()
        {
            _wires = Utilities.GetItemsFromRayCast<WireService>(transform, 10f);

            var list = new List<string>();
            foreach (var wire in _wires)
            {
                list.Add(wire.name);
                wire.SpriteColor(VerifyPathToEnergyGenerator(wire, list));
            }
        }

        private void ConnectionToGas()
        {
            _gases = Utilities.GetItemsFromRayCast<GasService>(transform);

            var list = new List<string>();
            foreach (var gas in _gases)
            {
                list.Add(gas.name);
                gas.SpriteColor(VerifyPathToEnergyGenerator(gas, list));
            }
        }

        private void SpriteColor()
        {
            _sprite.color = Buffer > PowerConsume ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
        }
    }
}