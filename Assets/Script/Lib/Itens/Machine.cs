using Assets.Script.Util;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public const float CONNECTION = 1f;

    public MachineType Type;
    public bool Debug;

    public string Title { get; private set; }
    public int MaxBuffer { get; private set; }
    public int PowerConsume { get; private set; }
    public int TimeProcess { get; private set; }
    public int Buffer { get; private set; }
    public int TimerProcess { get; private set; }
    public IList<Material> Outputs { get; private set; }
    public IList<Material> Inputs { get; private set; }

    public int buffer;
    public int timeProcess;

    public TimerRun processorTimer;
    private TimerRun connectionTimer;
    private bool isOpen;
    private SpriteRenderer sprite;
    private IList<Gas> gases;
    private IList<Wire> wires;
    private bool isNecessaryEnergy;
    private bool isNecessaryOxigen;

    private IUIManager ui;

    public void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

        if (Type != null)
        {
            name = Type.title;

            MaxBuffer = Type.maxBuffer;
            PowerConsume = Type.powerConsume;
            TimerProcess = Type.timerProcess;
            Outputs = Type.outputs;
            Inputs = Type.inputs;

            Buffer = 0;
            isNecessaryEnergy = Inputs.Contains(Material.Energy);
            isNecessaryOxigen = Inputs.Contains(Material.Oxygen);
        }

        connectionTimer = new TimerRun();
        processorTimer = new TimerRun();

        Debug = false;
    }

    public void Update()
    {
        buffer = Buffer;
        timeProcess = TimeProcess;
        //MachineInterface();
    }

    private void FixedUpdate()
    {
        if (Buffer < 0) Buffer = 0;
        if (Buffer > MaxBuffer) Buffer = MaxBuffer;

        if (processorTimer.Run() >= TimeProcess)
        {
            MachineConsume();
            processorTimer.Reset();
        }

        if (connectionTimer.Run() >= 1f)
        {
            if (isNecessaryEnergy)
            {
                ConnectionToWire();
            }

            if (isNecessaryOxigen)
            {
                ConnectionToGas();
            }

            connectionTimer.Reset();
        }
    }

    private void MachineInterface()
    {
        var ray = Utilities.GetRaycastHitFromScreenPoint();
        if (ray.HasValue)
        {
            if (ray.GetValueOrDefault().collider.name == name)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && !ui.IsOpen)
                {
                    isOpen = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && ui.IsOpen && isOpen)
        {
            isOpen = false;
            ui.CloseInventory(this);
        }

        if (isOpen) ui.ShowInventory(this);
    }

    private bool VerifyPathToEnergyGenerator(Wire wire, List<string> list)
    {
        var nextWire = wire.Next(last: list);
        if (nextWire != null)
        {
            var resultado = VerifyPathToEnergyGenerator(nextWire, list);
            nextWire.SpriteColor(resultado);
            return resultado;
        }
        else if (Utilities.GetItemsFromRayCast<Generator>(wire.transform, CONNECTION).Count != 0)
        {
            foreach (var generator in Utilities.GetItemsFromRayCast<Generator>(wire.transform, CONNECTION))
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

    private bool VerifyPathToEnergyGenerator(Gas gas, List<string> list)
    {
        var nextGas = gas.Next(last: list);
        if (nextGas != null)
        {
            var resultado = VerifyPathToEnergyGenerator(nextGas, list);
            nextGas.SpriteColor(resultado);
            return resultado;
        }
        else if (Utilities.GetItemsFromRayCast<Generator>(gas.transform, CONNECTION).Count != 0)
        {
            foreach (var generator in Utilities.GetItemsFromRayCast<Generator>(gas.transform, CONNECTION))
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
        wires = Utilities.GetItemsFromRayCast<Wire>(transform, CONNECTION);

        var list = new List<string>();
        foreach (var wire in wires)
        {
            list.Add(wire.name);
            wire.SpriteColor(VerifyPathToEnergyGenerator(wire, list));
        }
    }

    private void ConnectionToGas()
    {
        gases = Utilities.GetItemsFromRayCast<Gas>(transform, CONNECTION);
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

    private void MachineConsume()
    {
        if (Buffer > PowerConsume)
        {
            Buffer -= PowerConsume;
        }

        SpritColor();
    }

    private void SpritColor()
    {
        sprite.color = Buffer > 0 ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
    }
}