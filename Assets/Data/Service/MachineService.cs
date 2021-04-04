using Assets.Data.Enum;
using Assets.Data.Model;
using Assets.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Material = Assets.Data.Enum.Material;

namespace Assets.Data.Service
{
    public class MachineService : MonoBehaviour
    {
        public const float CONNECTION_MACHINES = 1.5f;
        public const float CONNECTION_PIPES = 1.5f;

        public MachineModel Type;

        public float ProcessTime;
        public int Buffer;
        public int Amount;

        private SpriteRenderer _sprite;

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

            name = Type.Title;
            Buffer = 0;
            _isNecessaryEnergy = Type.Inputs.Any(x => x.Material == Material.Energy);
            _isNecessaryOxygen = Type.Inputs.Any(x => x.Material == Material.Oxygen);
        }

        public void Update()
        {
            if (_viewHandler.MainScreen.WindowsMachine.gameObject.activeSelf)
                _viewHandler.WindowsMachineService.UpdateInterfaceMachine(new WindowsMachineItemModel
                {
                    buffer = Buffer,
                    maxBuffer = Type.MaxBuffer,
                    Power = Type.Power,
                    processTime = (int)ProcessTime,
                    maxProcessTime = Type.MaxProcessTime,
                    title = name,
                    InputAmount = Type.Inputs.Count,
                    OutputAmount = Type.Outputs.Count
                });
        }

        private void FixedUpdate()
        {
            if (Buffer < 0) Buffer = 0;
            if (Buffer > Type.MaxBuffer) Buffer = Type.MaxBuffer;

            switch (Type.Category)
            {
                case CategoryItemEnum.Generator:
                    GeneratorProcessor();
                    break;

                case CategoryItemEnum.Machine:
                    MachineProcessor();
                    break;

                case CategoryItemEnum.Wire:
                    break;

                case CategoryItemEnum.Gas:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            SpriteColor();
        }

        private void GeneratorProcessor()
        {
            if (TimerRun.Run(1f, ref _oneSecondProcessTimerRunner))
            {
                Consume();
                Powered();
            }
        }

        private void MachineProcessor()
        {
            if (Buffer > Type.Power)
            {
                if (TimerRun.Run(1f, ref _oneSecondProcessTimerRunner))
                {
                    if (Buffer >= Type.Power)
                        ProcessTime++;

                    if (_isNecessaryEnergy)
                    {
                        ConnectionToPipe(CategoryItemEnum.Wire);
                    }

                    if (_isNecessaryOxygen)
                    {
                        ConnectionToPipe(CategoryItemEnum.Gas);
                    }
                }

                if (TimerRun.Run(Type.MaxProcessTime, ref _maxProcessTimeRunner) && Buffer >= Type.Power)
                {
                    Buffer -= Type.Power;
                    ProcessTime = 0;
                }
            }
        }

        private void MachineInterface()
        {
            var ray = Utilities.GetMousePositionInRaycastHit();
            if (ray.HasValue)
            {
                if (ray.GetValueOrDefault().collider.name.Contains(Type.Title))
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

        public void SpriteColor(bool active)
        {
            if (_sprite != null)
                _sprite.color = active ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
        }

        private bool VerifyPathToEnergyGenerator(CategoryItemEnum category, MachineService item,
            List<string> list)
        {
            MachineService next;

            switch (category)
            {
                case CategoryItemEnum.Wire:
                    {
                        next = item.NextWire(last: list);
                        break;
                    }
                case CategoryItemEnum.Gas:
                    {
                        next = item.NextGas(last: list);
                        break;
                    }
                default:
                    return false;
            }

            if (next != null)
            {
                var result = VerifyPathToEnergyGenerator(category, next, list);
                next.SpriteColor(result);
                return result;
            }

            var generators = Utilities.GetItemsFromRayCast<MachineService>(item.transform, CONNECTION_PIPES)
                .Where(x => x.Type.Category == CategoryItemEnum.Generator);

            if (generators.Count() != 0)
            {
                foreach (var generator in Utilities.GetItemsFromRayCast<MachineService>(item.transform, CONNECTION_PIPES))
                {
                    foreach (var material in generator.Type.Outputs)
                    {
                        if (Type.Inputs.Contains(material) && Buffer < Type.MaxBuffer)
                            Buffer += generator.GetBufferFromPowerConsume(Type.Power);
                    }
                }

                return true;
            }

            return false;
        }

        private void ConnectionToPipe(CategoryItemEnum category)
        {
            var pipes = Utilities.GetItemsFromRayCast<MachineService>(transform, CONNECTION_PIPES)
                .Where(x => x.Type.Category == category)
                .ToList();

            var list = new List<string>();
            foreach (var wire in pipes)
            {
                list.Add(wire.name);
                wire.SpriteColor(VerifyPathToEnergyGenerator(category, wire, list));
            }
        }

        private void SpriteColor()
        {
            if (_sprite != null)
                _sprite.color = Buffer > Type.Power ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
        }

        public int GetBufferFromPowerConsume(int powerConsume)
        {
            if (Buffer - powerConsume >= 0)
            {
                Buffer -= powerConsume;
                return powerConsume;
            }
            else return 0;
        }

        private void Powered()
        {
            if (ProcessTime > 0 && Buffer < Type.MaxBuffer)
            {
                ProcessTime--;

                Buffer += Type.Power;
                if (Buffer >= Type.MaxBuffer)
                    Buffer = Type.MaxBuffer;
            }
        }

        private void Consume()
        {
            if (ProcessTime == 0 && Amount != 0)
            {
                Amount--;
                ProcessTime = 1 * Type.MaxProcessTime;
            }
        }

        public MachineService NextWire(List<string> last)
        {
            var wires = Utilities
                .GetItemsFromRayCast<MachineService>(transform, 1.5f)
                .Where(x => x.Type.Category == CategoryItemEnum.Wire);

            return FindMachineService(last, wires);
        }

        public MachineService NextGas(List<string> last)
        {
            var gases = Utilities
                .GetItemsFromRayCast<MachineService>(transform, 1.5f)
                .Where(x => x.Type.Category == CategoryItemEnum.Gas);

            return FindMachineService(last, gases);
        }

        private static MachineService FindMachineService(List<string> lastItemsAround, IEnumerable<MachineService> listPipe)
        {
            foreach (var wire in listPipe)
            {
                if (lastItemsAround.Contains(wire.name)) continue;
                else
                {
                    lastItemsAround.Add(wire.name);
                    return wire;
                }
            }

            return null;
        }
    }
}