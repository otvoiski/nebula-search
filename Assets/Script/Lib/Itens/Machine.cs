using Assets.Script.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public const int BUFFER_LIMIT = 250;
    public const float WIRE_CONNECT = 1f;

    public float TimeProcess = 10f;
    public string Title = "Machine";
    public int buffer;
    public int machineUse;
    public TimerRun processorTimer;

    public bool debug;

    private TimerRun connectionTimer;
    private bool isOpen;
    private SpriteRenderer sprite;
    private List<Wire> wires;
    private IUIManager ui;

    public void Setup(Func<IUIManager> ui)
    {
        connectionTimer = new TimerRun();
        processorTimer = new TimerRun();
        sprite = GetComponentInChildren<SpriteRenderer>();
        buffer = 0;
        machineUse = 120;
        debug = false;
        this.ui = ui();
    }

    public void Update()
    {
        MachineInterface();
    }

    private void FixedUpdate()
    {
        if (buffer < 0) buffer = 0;
        if (buffer > BUFFER_LIMIT) buffer = BUFFER_LIMIT;

        if (processorTimer.Run() >= TimeProcess)
        {
            MachineConsume();
            processorTimer.Reset();
        }

        if (connectionTimer.Run() >= 1f)
        {
            ConnectionToWire();
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
            //Debug.Log(nextWire);

            var resultado = VerifyPathToEnergyGenerator(nextWire, list);
            nextWire.SpriteColor(resultado);
            return resultado;
        }
        else if (Utilities.GetItemsFromRayCast<Generator>(wire.transform, WIRE_CONNECT).Count != 0)
        {
            foreach (var generators in Utilities.GetItemsFromRayCast<Generator>(wire.transform, 1f))
            {
                // melhorar isto
                buffer += generators.GetEnergy(23);
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
        wires = Utilities.GetItemsFromRayCast<Wire>(transform, WIRE_CONNECT);
        if (wires.Count > 0)
        {
            var list = new List<string>();
            foreach (var wire in wires)
            {
                list.Add(wire.name);
                wire.SpriteColor(VerifyPathToEnergyGenerator(wire, list));
            }
        }
    }

    private void MachineConsume()
    {
        if (buffer > machineUse)
        {
            if (debug) Debug.Log($"The {name} executed process ===> {machineUse}/{buffer}");
            buffer -= machineUse;
        }

        SpritColor();
    }

    private void SpritColor()
    {
        sprite.color = buffer > 0 ? new Color(0, 1, 0, .200f) : new Color(1, 0, 0, .200f);
    }
}