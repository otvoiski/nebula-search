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
    public GeneratorModel Type;

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

    private SpriteRenderer _sprite;
    private float _timer;
    private ViewHandler _viewHandler;
    private InputMaster _input;

    private void Awake()
    {
        _input = new InputMaster();
        _input.MachineScreen.ClickMachine.performed += _ => GeneratorInterface();

        _viewHandler = GameObject.Find("VIEW HANDLER")
            .GetComponent<ViewHandler>();
    }

    private void Enable()
    {
        _input.MachineScreen.Enable();
    }

    private void Disable()
    {
        _input.MachineScreen.Disable();
    }

    public void Start()
    {
        if (Type != null)
        {
            name = Type.title;

            Title = Type.title;
            MaxBuffer = Type.maxBuffer;
            PowerGenerator = Type.powerGenerator;
            Title = Type.title;
            MaxProcessTime = Type.maxProcessTime;
            Inputs = Type.inputs;
            Output = Type.outputs[0];
        }

        _sprite = GetComponentInChildren<SpriteRenderer>();

        Amount = 2;
    }

    public void Update()
    {
        if (_viewHandler.MainScreen.WindowsMachine.gameObject.activeSelf)
            _viewHandler.WindowsMachineService.UpdateInterfaceMachine(new WindowsMachineItemModel
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

    private void FixedUpdate()
    {
        if (TimerRun.Run(1f, ref _timer))
        {
            Consume();
            Powered();

            BatteryLight();
        }

        if (Buffer < 0) Buffer = 0;
        if (Buffer > MaxBuffer) Buffer = MaxBuffer;
    }

    private void GeneratorInterface()
    {
        var ray = Utilities.GetMousePositionInRaycastHit();
        if (ray.HasValue)
        {
            if (ray.GetValueOrDefault().collider.name.Contains(Title))
            {
                if (!ViewHandler.IsOpen)
                {
                    _viewHandler.MainScreen.WindowsMachine.gameObject.SetActive(true);
                    ViewHandler.IsOpen = true;
                }
            }
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

    private void BatteryLight()
    {
        _sprite.color = Buffer > 0
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
        return Type;
    }
}