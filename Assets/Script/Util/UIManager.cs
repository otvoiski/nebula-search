using Assets.Script.Enumerator;
using Assets.Script.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIManager
{
    private enum Item
    {
        Title = 0,
        Value = 1
    }

    private RectTransform generatorInterface;
    private RectTransform interfaceMenu;
    private RectTransform interfaceItem;

    public bool IsOpen { get; private set; }

    public void Setup()
    {
        var ui = GameObject
            .Find("UI")
            .transform
            .Find("MainScreen");

        var interfaceItemPrefab = Resources.Load("UI/InterfaceItem") as GameObject;

        this.generatorInterface = ui.Find("Generator Interface").GetComponent<RectTransform>();
        this.interfaceMenu = ui.Find("Interface Menu").GetComponent<RectTransform>();
        this.interfaceItem = interfaceItemPrefab.GetComponent<RectTransform>();

        interfaceItem.localScale = Vector3.one;
        IsOpen = false;
    }

    public void ShowInventory(Machine machine)
    {
        if (machine != null)
        {
            IsOpen = true;

            interfaceMenu
                .GetChild(0)
                .GetComponentInChildren<Text>()
                .text = Locate.Translate["Machine"][machine.Title].ToString();

            var body = interfaceMenu.GetChild(1);
            if (body.childCount < 3)
            {
                var machineUse = Instantiate(interfaceItem, body);
                var buffer = Instantiate(interfaceItem, body);
                var timer = Instantiate(interfaceItem, body);

                machineUse.SetParent(body);
                buffer.SetParent(body);
                timer.SetParent(body);

                machineUse.name = "Machine Use";
                buffer.name = "Buffer";
                timer.name = "Timer";
            }
            else
            {
                ChangeUIItem(body.GetChild(0), Locate.Translate["Machine"]["MachineUse"].ToString(), $"{ machine.machineUse } μ");
                ChangeUIItem(body.GetChild(1), Locate.Translate["Machine"]["Buffer"].ToString(), $"{ machine.buffer }/{Machine.BUFFER_LIMIT}");
                ChangeUIItem(body.GetChild(2), Locate.Translate["Machine"]["Timer"].ToString(), $"{Mathf.RoundToInt(machine.processorTimer.timer)}/{machine.TimeProcess}");
            }

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

    public void ShowInventory(Generator generator)
    {
        // Topbar
        if (generator != null)
        {
            IsOpen = true;

            #region Top

            var top = generatorInterface.GetChild(0);
            top.GetComponentInChildren<Text>().text = Generator.TITLE;

            #endregion Top

            #region Body

            var body = generatorInterface.GetChild(1);
            var right = body.GetChild(1);

            right.Find("Power Generator").GetChild(1).GetComponentInChildren<Text>().text = $"{ generator.power } μ";
            right.Find("Buffer").GetChild(1).GetComponentInChildren<Text>().text = generator.buffer.ToString();
            right.Find("Amount").GetChild(1).GetComponentInChildren<Text>().text = generator.amount.ToString();
            right.Find("Combustion Timer").GetChild(1).GetComponentInChildren<Text>().text = generator.combustionTime.ToString();
            right.Find("Material").GetChild(1).GetComponentInChildren<Text>().text = generator.material.ToString();

            #endregion Body

            generatorInterface.gameObject.SetActive(IsOpen);
        }
    }

    public void CloseInventory(Generator generator)
    {
        IsOpen = false;

        generatorInterface.gameObject.SetActive(IsOpen);

        #region Top

        var top = generatorInterface.GetChild(0);
        top.GetComponentInChildren<Text>().text = "";

        #endregion Top

        #region Body

        var body = generatorInterface.GetChild(1);
        var left = body.GetChild(1);

        left.Find("Power Generator").GetChild(1).GetComponentInChildren<Text>().text = "";
        left.Find("Buffer").GetChild(1).GetComponentInChildren<Text>().text = "";
        left.Find("Amount").GetChild(1).GetComponentInChildren<Text>().text = "";
        left.Find("Combustion Timer").GetChild(1).GetComponentInChildren<Text>().text = "";
        left.Find("Material").GetChild(1).GetComponentInChildren<Text>().text = "";

        #endregion Body
    }
}

public interface IUIManager
{
    bool IsOpen { get; }

    void Setup();

    void ShowInventory(Generator generator);

    void CloseInventory(Generator generator);

    void ShowInventory(Machine machine);

    void CloseInventory(Machine machine);
}