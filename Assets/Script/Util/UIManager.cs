using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private enum MainScreen
    {
        BottomBar,
        ToastBar,
        InterfaceMenu,
        Build
    }

    private enum InterfaceMenu
    {
        Title,
        Inventory,
        IO,
        Button,
        ProcessMenu
    }

    private enum ItemType
    {
        Title,
        Value,
        Icon
    }

    private enum Body
    {
        Energy,
        Process,
        Input,
        Output,
        Others
    }

    private enum ProcessMenu
    {
        Energy,
        TimeProcess
    }

    private enum InfoScreen
    {
        Energy,
        ProcessTime,
        PowerConsume
    }

    private Transform mainScreen;
    private Transform interfaceMenu;
    private Text title;
    private Transform inventory;
    private Slider energyPower;
    private Slider timeProcess;
    private Transform buildScreen;
    public static InterfaceItem Item;
    private GameObject infoScreen;

    public bool IsOpen { get; private set; }

    public void Start()
    {
        mainScreen = GameObject.Find("UI").transform.Find("MainScreen");
        interfaceMenu = mainScreen.GetChild((int)MainScreen.InterfaceMenu);

        title = interfaceMenu.GetChild((int)InterfaceMenu.Title).GetComponentInChildren<Text>();
        inventory = interfaceMenu.GetChild((int)InterfaceMenu.Inventory);

        var processMenu = interfaceMenu.GetChild((int)InterfaceMenu.ProcessMenu);
        energyPower = processMenu.GetChild((int)ProcessMenu.Energy).GetComponentInChildren<Slider>();
        timeProcess = processMenu.GetChild((int)ProcessMenu.TimeProcess).GetComponentInChildren<Slider>();

        buildScreen = mainScreen.GetChild((int)MainScreen.Build);

        IsOpen = false;
    }

    public void ToggleWindowsBuild(bool isBuilding)
    {
        buildScreen.gameObject.SetActive(isBuilding);
    }

    public void ShowInterfaceItens()
    {
        if (Item != null)
        {
            IsOpen = true;

            title.text = Locate.Translate["Machine"][Item.Title]?.ToString() ?? Item.Title;

            energyPower.maxValue = Item.MaxBuffer;
            energyPower.value = Item.Buffer;

            timeProcess.maxValue = Item.MaxProcessTime;
            timeProcess.value = Item.ProcessTime;

            interfaceMenu.gameObject.SetActive(IsOpen);

            if (Item != null && infoScreen != null)
            {
                infoScreen.transform.GetChild((int)InfoScreen.Energy).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = $"{Item.Buffer}/{Item.MaxBuffer}";
                infoScreen.transform.GetChild((int)InfoScreen.ProcessTime).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = $"{Item.ProcessTime}/{Item.MaxProcessTime}";
                infoScreen.transform.GetChild((int)InfoScreen.PowerConsume).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = $"{Item.PowerConsume}";
            }
        }
    }

    public void CloseInterfaceItens()
    {
        IsOpen = false;
        title.text = "";
        Item = null;
        interfaceMenu.gameObject.SetActive(IsOpen);
    }

    public void ToggleWindowsInformation(GameObject infoScreen)
    {
        if (!infoScreen.activeSelf)
        {
            this.infoScreen = infoScreen;
            infoScreen.SetActive(true);
        }
        else
        {
            infoScreen.transform.GetChild((int)InfoScreen.Energy).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = "";
            infoScreen.transform.GetChild((int)InfoScreen.ProcessTime).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = "";
            infoScreen.transform.GetChild((int)InfoScreen.PowerConsume).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = "";

            this.infoScreen = null;
            infoScreen.SetActive(false);
        }
    }
}