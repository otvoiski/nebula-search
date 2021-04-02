using Assets.Data.Service;
using Assets.Data.Util;
using System.Collections;
using System.Collections.Generic;
using Assets.Data.Enum;
using UnityEngine;

namespace Assets.Data
{
    public class GameHandler : MonoBehaviour
    {
        public InputMaster Input;
        public static IDictionary<string, IList> Items;

        private void Awake()
        {
            Input = new InputMaster();
        }

        private void Start()
        {
            Locale.LoadLocate(Language.BR);

            LoadItems();

            DontDestroyOnLoad(gameObject);
        }

        private void LoadItems()
        {
            Items = new Dictionary<string, IList>();

            var items = Resources.LoadAll<GameObject>("Items") as GameObject[];

            var generators = new List<GeneratorService>();
            var machines = new List<MachineService>();
            var wires = new List<WireService>();
            var gases = new List<GasService>();
            foreach (var item in items)
            {
                var generator = item.GetComponent<GeneratorService>();
                if (generator != null)
                {
                    generators.Add(item.GetComponent<GeneratorService>());
                    continue;
                }

                var machine = item.GetComponent<MachineService>();
                if (machine != null)
                {
                    machines.Add(item.GetComponent<MachineService>());
                    continue;
                }

                var wire = item.GetComponent<WireService>();
                if (wire != null)
                {
                    wires.Add(item.GetComponent<WireService>());
                    continue;
                }

                var gas = item.GetComponent<GasService>();
                if (gas != null)
                {
                    gases.Add(item.GetComponent<GasService>());
                    continue;
                }
            }

            Items.Add($"{CategoryItemEnum.Generator}", generators);
            Items.Add($"{CategoryItemEnum.Machine}", machines);
            Items.Add($"{CategoryItemEnum.Wire}", wires);
            Items.Add($"{CategoryItemEnum.Gas}", gases);
        }

        private void OnEnable()
        {
            Input.Enable();
        }

        private void OnDisable()
        {
            Input.Disable();
        }
    }
}