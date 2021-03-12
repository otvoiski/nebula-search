using Assets.Script.Enumerator;
using Assets.Script.Util;
using System;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GeneratorType type;

    #region type

    public string Title { get; private set; }
    public int MaxBuffer { get; private set; }
    public int Amount { get; private set; }
    public int PowerGenerator { get; private set; }
    public int Buffer { get; private set; }
    public int CombustionTime { get; private set; }
    public int ProcessTime { get; private set; }
    public Material[] Inputs { get; private set; }
    public Material Output { get; private set; }

    #endregion type

    private TimerRun timer;
    private SpriteRenderer sprite;
    private bool isOpen;

    public void Start()
    {
        if (type != null)
        {
            name = type.title;

            Title = type.title;
            MaxBuffer = type.maxBuffer;
            PowerGenerator = type.powerGenerator;
            Title = type.title;
            ProcessTime = type.processTime;
            Inputs = type.inputs;
            Output = type.output;
        }

        timer = new TimerRun();
        sprite = GetComponentInChildren<SpriteRenderer>();

        Amount = 1;
    }

    public void Setup(IUIManager ui)
    {
    }

    public void Update()
    {
        //GeneratorInterface();
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

        if (Buffer < 0) Buffer = 0;
        if (Buffer > MaxBuffer) Buffer = MaxBuffer;
    }

    private void GeneratorInterface()
    {
        //try
        //{
        //    var ray = Utilities.GetRaycastHitFromScreenPoint();
        //    if (ray.HasValue)
        //    {
        //        // TODO: A instancia do item deve ter o nome mudado
        //        if (ray.GetValueOrDefault().collider.name.Contains(Title))
        //        {
        //            if (Input.GetKeyDown(KeyCode.Mouse0) && !ui.IsOpen)
        //            {
        //                isOpen = true;
        //            }
        //        }
        //    }

        //    if (Input.GetKeyDown(KeyCode.Escape) && ui.IsOpen && isOpen)
        //    {
        //        isOpen = false;
        //        ui.CloseInventory(this);
        //    }

        //    if (isOpen) ui.ShowInventory(this);
        //}
        //catch (Exception ex)
        //{
        //    Toast.Message(ToastType.Error, "Exception", ex.Message);
        //    Debug.LogException(ex);
        //}
    }

    public int GetBufferFromRate(int rate)
    {
        if (Buffer > 0)
        {
            Buffer -= rate;
            if (rate > Buffer) return Buffer;
            else return rate;
        }
        else
        {
            return 0;
        }
    }

    private void BateryLight()
    {
        sprite.color = Buffer > 0
            ? new Color(0, 1, 0, .200f)
            : new Color(1, 0, 0, .200f);
    }

    private void Powered()
    {
        if (CombustionTime > 0 && Buffer < MaxBuffer)
        {
            CombustionTime--;

            Buffer += PowerGenerator;
            if (Buffer >= MaxBuffer)
                Buffer = MaxBuffer;
        }
    }

    private void Consume()
    {
        if (CombustionTime == 0 && Amount != 0)
        {
            Amount--;
            CombustionTime = 1 * ProcessTime;
        }
    }
}