using Assets.Script.Enumerator;
using Assets.Script.Util;
using Assets.Script.View;
using Assets.Script.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MachineService : MonoBehaviour
{
    public const float CONNECTION = 1f;

    public MachineModel type;
    public bool debug;

    public string Title { get; private set; }
    public int MaxBuffer { get; private set; }
    public int PowerConsume { get; private set; }
    public int Buffer { get; private set; }
    public int MaxProcessTime { get; private set; }
    public int ProcessTime { get; private set; }
    public IList<Material> Outputs { get; private set; }
    public IList<Material> Inputs { get; private set; }

    private SpriteRenderer sprite;
    private IList<GasService> gases;
    private IList<WireService> wires;
    private bool isNecessaryEnergy;
    private bool isNecessaryOxigen;

    private float oneSecondProcessTimerRunner;
    private float maxProcessTimeRunner;
    private ViewHandler _viewHandler;

    private void Awake()
    {
        _viewHandler = GameObject.Find("VIEW HANDLER")
            .GetComponent<ViewHandler>();
    }

    public void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

        if (type != null)
        {
            name = type.title;
            Title = type.title;

            MaxBuffer = type.maxBuffer;
            PowerConsume = type.powerConsume;
            MaxProcessTime = type.maxProcessTime;
            Outputs = type.outputs;
            Inputs = type.inputs;

            Buffer = 0;
            isNecessaryEnergy = Inputs.Contains(Material.Energy);
            isNecessaryOxigen = Inputs.Contains(Material.Oxygen);
        }

        debug = false;
    }

    public void Update()
    {
        MachineInterface();
    }

    private void FixedUpdate()
    {
        if (Buffer < 0) Buffer = 0;
        if (Buffer > MaxBuffer) Buffer = MaxBuffer;

        if (TimerRun.Run(1f, ref oneSecondProcessTimerRunner))
        {
            if (Buffer >= PowerConsume)
                ProcessTime++;

            if (isNecessaryEnergy)
            {
                ConnectionToWire();
            }

            if (isNecessaryOxigen)
            {
                ConnectionToGas();
            }
        }

        if (TimerRun.Run(MaxProcessTime, ref maxProcessTimeRunner) && Buffer >= PowerConsume)
        {
            Buffer -= PowerConsume;
            ProcessTime = 0;
        }

        SpriteColor();
    }

    private void MachineInterface()
    {
        try
        {
            var ray = Utilities.GetRaycastHitFromScreenPoint();
            if (ray.HasValue)
            {
                if (ray.GetValueOrDefault().collider.name.Contains(Title))
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        _viewHandler.ShowInterfaceMachine();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _viewHandler.CloseInterfaceMachine();
            }

            _viewHandler.UpdateInterfaceMachine(new WindowsMachineItemModel
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
        catch (Exception ex)
        {
            Toast.Message(ToastType.Error, "Exception", ex.Message);
            Debug.LogException(ex);
        }
    }

    private bool VerifyPathToEnergyGenerator(WireService wire, List<string> list)
    {
        var nextWire = wire.Next(last: list);
        if (nextWire != null)
        {
            var resultado = VerifyPathToEnergyGenerator(nextWire, list);
            nextWire.SpriteColor(resultado);
            return resultado;
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
            var resultado = VerifyPathToEnergyGenerator(nextGas, list);
            nextGas.SpriteColor(resultado);
            return resultado;
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
        wires = Utilities.GetItemsFromRayCast<WireService>(transform, CONNECTION);

        var list = new List<string>();
        foreach (var wire in wires)
        {
            list.Add(wire.name);
            wire.SpriteColor(VerifyPathToEnergyGenerator(wire, list));
        }
    }

    private void ConnectionToGas()
    {
        gases = Utilities.GetItemsFromRayCast<GasService>(transform, CONNECTION);
        if (gases.Count > 0)
        {
            var list = new List<string>();
            foreach (var gas in gases)
            {
                list.Add(gas.name);
                gas.SpriteColor(VerifyPathToEnergyGenerator(gas, list));
            }
        }
    }

    private void SpriteColor()
    {
        sprite.color = Buffer > PowerConsume ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
    }
}