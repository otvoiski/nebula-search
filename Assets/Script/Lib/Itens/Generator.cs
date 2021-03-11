using Assets.Script.Enumerator;
using Assets.Script.Util;
using System;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public const string TITLE = "Generator";
    public const int BUFFER_LIMIT = 1200;

    public Material material;
    public int amount;
    public int power;
    public int buffer;
    public int combustionTime;

    private TimerRun timer;
    private SpriteRenderer sprite;
    private IUIManager ui;
    private bool isOpen;

    public void Setup(Func<IUIManager> ui)
    {
        this.ui = ui();
        timer = new TimerRun();
        sprite = GetComponentInChildren<SpriteRenderer>();
        power = Utilities.GetEnergyByMaterial(material);
        amount = 1;
        buffer = 0;
    }

    public void Update()
    {
        GeneratorInterface();
    }

    private void FixedUpdate()
    {
        if (timer.Run() >= 1)
        {
            Consume();
            Powered();

            BateryLight();

            timer.Reset();
        }

        if (buffer < 0) buffer = 0;
        if (buffer > BUFFER_LIMIT) buffer = BUFFER_LIMIT;
    }

    private void GeneratorInterface()
    {
        try
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
        catch (Exception ex)
        {
            Toast.Message(ToastType.Error, "Exception", ex.Message);
            Debug.LogException(ex);
        }
    }

    public int GetEnergy(int energy)
    {
        if (buffer > 0)
        {
            buffer -= energy;
            if (energy > buffer) return buffer;
            else return energy;
        }
        else
        {
            return 0;
        }
    }

    private void BateryLight()
    {
        sprite.color = buffer > 0
            ? new Color(0, 1, 0, .200f)
            : new Color(1, 0, 0, .200f);
    }

    private void Powered()
    {
        if (combustionTime > 0 && buffer < BUFFER_LIMIT)
        {
            combustionTime--;

            buffer += power;
            if (buffer >= BUFFER_LIMIT)
                buffer = BUFFER_LIMIT;
        }
    }

    private void Consume()
    {
        if (combustionTime == 0 && amount != 0)
        {
            amount--;
            combustionTime = 1 * 60;
        }
    }
}