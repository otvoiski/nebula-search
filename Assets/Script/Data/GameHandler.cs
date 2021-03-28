using Assets.Script.Data.Enum;
using Assets.Script.Data.Model;
using Assets.Script.Enumerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public InputMaster Input;
    public static IDictionary<string, IList> Itens;

    private void Awake()
    {
        Input = new InputMaster();
    }

    private void Start()
    {
        Locate.LoadLocate(Language.BR);

        LoadItens();

        DontDestroyOnLoad(gameObject);
    }

    private void LoadItens()
    {
        Itens = new Dictionary<string, IList>();

        var itens = Resources.LoadAll<GameObject>("Itens") as GameObject[];

        var generators = new List<GeneratorService>();
        var machines = new List<MachineService>();
        var wires = new List<WireService>();
        var gases = new List<GasService>();
        foreach (var item in itens)
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

        Itens.Add($"{CategoryItemEnum.Generator}", generators);
        Itens.Add($"{CategoryItemEnum.Machine}", machines);
        Itens.Add($"{CategoryItemEnum.Wire}", wires);
        Itens.Add($"{CategoryItemEnum.Gas}", gases);
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