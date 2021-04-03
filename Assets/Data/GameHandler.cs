using Assets.Data.Enum;
using Assets.Data.Service;
using Assets.Data.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Data.Model;
using Assets.Data.Util.DeveloperConsole;
using UnityEngine;

namespace Assets.Data
{
    public class GameHandler : MonoBehaviour
    {
        public static IDictionary<string, IList<MachineModel>> Items;

        private void Start()
        {
            Locale.LoadLocate(Language.BR);

            LoadItems();

            DontDestroyOnLoad(gameObject);
        }

        private static void LoadItems()
        {
            Items = new Dictionary<string, IList<MachineModel>>();

            var items = Resources.LoadAll<MachineModel>("Items");

            var generators = new List<MachineModel>();
            var machines = new List<MachineModel>();
            var wires = new List<MachineModel>();
            var gases = new List<MachineModel>();

            foreach (var machine in items)
            {
                if (machine != null)
                {
                    switch (machine.Category)
                    {
                        case CategoryItemEnum.Generator:
                            generators.Add(machine);
                            break;

                        case CategoryItemEnum.Machine:
                            machines.Add(machine);
                            break;

                        case CategoryItemEnum.Wire:
                            wires.Add(machine);
                            break;

                        case CategoryItemEnum.Gas:
                            gases.Add(machine);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            Items.Add($"{CategoryItemEnum.Generator}", generators);
            Items.Add($"{CategoryItemEnum.Machine}", machines);
            Items.Add($"{CategoryItemEnum.Wire}", wires);
            Items.Add($"{CategoryItemEnum.Gas}", gases);

            if (!Items.Any()) ConsoleCommand.PrintOnConsole("Game Items can't loaded!", Color.red);
        }
    }
}