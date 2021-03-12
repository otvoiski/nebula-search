using Assets.Script.Enumerator;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private enum MainScreen
    {
        BottomBar = 0,
        ToastBar = 1,
        InterfaceMenu = 2
    }

    private enum InterfaceMenu
    {
        Title = 0,
        Body = 1,
        Inventory = 2,
    }

    private enum Item
    {
        Title = 0,
        Text = 1,
        Icon = 2
    }

    private enum Body
    {
        Energy = 0,
        Process = 1,
        Input = 2,
        Output = 3,
        Others = 4
    }

    private Transform interfaceMenu;
    private Text title;

    private Transform energyPower;
    private Transform timeProcess;
    private Transform inventory;

    public bool IsOpen { get; private set; }

    public void Start()
    {
        interfaceMenu = GameObject.Find("UI").transform.Find("MainScreen");

        title = interfaceMenu.GetChild((int)InterfaceMenu.Title).GetComponentInChildren<Text>();

        var body = interfaceMenu.GetChild((int)InterfaceMenu.Body);
        energyPower = body.GetChild((int)Body.Energy).GetChild(0);
        timeProcess = body.GetChild((int)Body.Process).GetChild(0);

        inventory = interfaceMenu.GetChild((int)InterfaceMenu.Inventory);
        IsOpen = false;
    }

    public void ShowInterfaceItens(string title, int buffer, int timeProcess)
    {
        IsOpen = true;

        this.title.text = Locate.Translate["Machine"][title]?.ToString() ?? title;

        ChangeUIItem(body.GetChild(0), Locate.Translate["Machine"]["MachineUse"].ToString(), $"{ machine.PowerConsume } μ");
        ChangeUIItem(body.GetChild(1), Locate.Translate["Machine"]["Buffer"].ToString(), $"{ machine.Buffer }/{machine.MaxBuffer}");
        ChangeUIItem(body.GetChild(2), Locate.Translate["Machine"]["Timer"].ToString(), $"{Mathf.RoundToInt(machine.processorTimer.timer)}/{machine.TimeProcess}");

        interfaceMenu.gameObject.SetActive(IsOpen);
    }

    public void ShowInventory(Machine machine)
    {
        if (machine != null)
        {
            IsOpen = true;

            title.text = Locate.Translate["Machine"][machine.Title]?.ToString();

            ChangeUIItem(body.GetChild(0), Locate.Translate["Machine"]["MachineUse"].ToString(), $"{ machine.PowerConsume } μ");
            ChangeUIItem(body.GetChild(1), Locate.Translate["Machine"]["Buffer"].ToString(), $"{ machine.Buffer }/{machine.MaxBuffer}");
            ChangeUIItem(body.GetChild(2), Locate.Translate["Machine"]["Timer"].ToString(), $"{Mathf.RoundToInt(machine.processorTimer.timer)}/{machine.TimeProcess}");

            interfaceMenu.gameObject.SetActive(IsOpen);
        }
    }

    private void ChangeUIItem(Transform transform, string title, string value)
    {
        transform.GetChild((int)Item.Title).GetComponentInChildren<Text>().text = title;
        transform.GetChild((int)Item.Value).GetComponentInChildren<Text>().text = value;
    }

    public void CloseInventory(Machine machine)
    {
        IsOpen = false;
        interfaceMenu.gameObject.SetActive(IsOpen);

        interfaceMenu
            .GetChild(0)
            .GetComponentInChildren<Text>()
            .text = "";

        var body = interfaceMenu.GetChild(1);
        for (int i = 0; i < body.childCount; i++)
        {
            try
            {
                body.GetChild(i).GetChild((int)Item.Title).GetComponentInChildren<Text>().text = "";
                body.GetChild(i).GetChild((int)Item.Value).GetComponentInChildren<Text>().text = "";
            }
            catch (Exception ex)
            {
                Toast.Message(ToastType.Error, "Exception", ex.Message);
                Debug.LogException(ex);
            }
        }
    }
}