using Assets.Script.Data.Enum;
using Assets.Script.Data.Model;
using Assets.Script.Enumerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public InputMaster _input;
    public static IDictionary<string, IList> Itens;

    private void Awake()
    {
        _input = new InputMaster();

        _input.ToastTest.ShowToast.performed += _ => Toast.Message(ToastType.Success, "Teste", "Menssage teste!");
    }

    private void Start()
    {
        Locate.LoadLocate(Language.BR);

        LoadItens();
    }

    private void LoadItens()
    {
        var itens = Resources.LoadAll<GameObject>("Itens");

        var generators = new List<GeneratorModel>();
        var machines = new List<MachineModel>();
        var pipes = new List<PipeModel>();
        foreach (var item in itens)
        {
            var category = item.GetComponent<CategoryItenModel>();
            switch (category.categoy)
            {
                case CategoryItenEnum.Generator:
                    generators.Add(item.GetComponent<GeneratorModel>());
                    break;

                case CategoryItenEnum.Machine:
                    machines.Add(item.GetComponent<MachineModel>());
                    break;

                case CategoryItenEnum.Pipe:
                    pipes.Add(item.GetComponent<PipeModel>());
                    break;

                case CategoryItenEnum.Floor:
                    break;

                case CategoryItenEnum.Wall:
                    break;

                default:
                    break;
            }
        }

        Itens.Add($"{CategoryItenEnum.Generator}", generators);
        Itens.Add($"{CategoryItenEnum.Machine}", machines);
        Itens.Add($"{CategoryItenEnum.Pipe}", pipes);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}