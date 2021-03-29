using Assets.Script.Data.Model;
using Assets.Script.Enumerator;
using Assets.Script.Util;
using Assets.Script.View;
using Assets.Script.View.Model;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IMachine
{
    CategoryItemModel GetType();
}

public class GeneratorService : MonoBehaviour, IMachine
{
    public GeneratorModel type;

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

    private SpriteRenderer sprite;
    private float timer;
    private ViewHandler _viewHandler;

    private void Awake()
    {
        _viewHandler = GameObject.Find("VIEW HANDLER")
            .GetComponent<ViewHandler>();
    }

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
            Output = type.outputs[0];
        }

        sprite = GetComponentInChildren<SpriteRenderer>();

        Amount = 0;
    }

    public void Update()
    {
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
            var ray = Utilities.GetMousePositionInRaycastHit();
            if (ray.HasValue)
            {
                if (ray.GetValueOrDefault().collider.name.Contains(Title))
                {
                    if (Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        _viewHandler.ShowInterfaceMachine();
                    }
                }
            }

            _viewHandler.UpdateInterfaceMachine(new WindowsMachineItemModel
            {
                buffer = Buffer,
                maxBuffer = MaxBuffer,
                maxProcessTime = MaxProcessTime,
                powerGenerator = PowerGenerator,
                processTime = ProcessTime,
                title = Title,
                InputAmount = Inputs.Length,
                OutputAmount = 1
            });
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

    CategoryItemModel IMachine.GetType()
    {
        return type;
    }
}