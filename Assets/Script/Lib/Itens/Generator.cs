using Assets.Script.Enumerator;
using Assets.Script.Util;
using System;
using UnityEngine;

public class Generator : MonoBehaviourExtended
{
    public GeneratorType type;

    #region type

    public string Title { get; private set; }
    public int MaxBuffer { get; private set; }
    public int Amount { get; private set; }
    public int PowerGenerator { get; private set; }
    public int Buffer { get; private set; }
    public int ProcessTime { get; private set; }
    public int MaxProcessTime { get; private set; }
    public Material[] Inputs { get; private set; }
    public Material Output { get; private set; }

    #endregion type

    [Component]
    private readonly UIManager ui;

    private SpriteRenderer sprite;
    private bool isOpen;
    private float timer;

    public void Start()
    {
        if (type != null)
        {
            name = type.title;

            Title = type.title;
            MaxBuffer = type.maxBuffer;
            PowerGenerator = type.powerGenerator;
            Title = type.title;
            MaxProcessTime = type.maxProcessTime;
            Inputs = type.inputs;
            Output = type.output;
        }

        sprite = GetComponentInChildren<SpriteRenderer>();

        Amount = 1;
    }

    public void Update()
    {
        if (ui != null)
            GeneratorInterface();
    }

    private void FixedUpdate()
    {
        if (TimerRun.Run(1f, ref timer))
        {
            Consume();
            Powered();

            BateryLight();
        }

        if (Buffer < 0) Buffer = 0;
        if (Buffer > MaxBuffer) Buffer = MaxBuffer;
    }

    private void GeneratorInterface()
    {
        try
        {
            var ray = Utilities.GetRaycastHitFromScreenPoint();
            if (ray.HasValue)
            {
                if (ray.GetValueOrDefault().collider.name.Contains(Title))
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && !ui.IsOpen && !GameHandler.IsBuilding)
                    {
                        isOpen = true;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && ui.IsOpen && isOpen)
            {
                isOpen = false;
                ui.CloseInterfaceItens();
            }

            if (isOpen)
            {
                UIManager.Item = new InterfaceItem
                {
                    Title = Title,
                    Buffer = Buffer,
                    MaxBuffer = MaxBuffer,
                    ProcessTime = ProcessTime,
                    MaxProcessTime = MaxProcessTime,
                    PowerConsume = PowerGenerator
                };

                ui.ShowInterfaceItens();
            }
        }
        catch (Exception ex)
        {
            Toast.Message(ToastType.Error, "Exception", ex.Message);
            Debug.LogException(ex);
        }
    }

    public int GetBufferFromRate(int powerConsume)
    {
        if (Buffer - powerConsume >= 0)
        {
            Buffer -= powerConsume;
            return powerConsume;
        }
        else return 0;
    }

    private void BateryLight()
    {
        sprite.color = Buffer > 0
            ? new Color(0, 1, 0, .200f)
            : new Color(1, 0, 0, .200f);
    }

    private void Powered()
    {
        if (ProcessTime > 0 && Buffer < MaxBuffer)
        {
            ProcessTime--;

            Buffer += PowerGenerator;
            if (Buffer >= MaxBuffer)
                Buffer = MaxBuffer;
        }
    }

    private void Consume()
    {
        if (ProcessTime == 0 && Amount != 0)
        {
            Amount--;
            ProcessTime = 1 * MaxProcessTime;
        }
    }
}