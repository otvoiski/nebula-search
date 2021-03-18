using UnityEngine;

public class UIManager : MonoBehaviour
{
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

    //private MainScreen MainScreen;

    public bool IsOpen { get; private set; }

    private void Awake()
    {
    }

    public void Start()
    {
    }

    #region Machines

    public void ShowInterfaceItens()
    {
        //if (Item != null)
        //{
        //    IsOpen = true;

        //    title.text = Locate.Translate["Machine"][Item.Title]?.ToString() ?? Item.Title;

        //    energyPower.maxValue = Item.MaxBuffer;
        //    energyPower.value = Item.Buffer;

        //    timeProcess.maxValue = Item.MaxProcessTime;
        //    timeProcess.value = Item.ProcessTime;

        //    interfaceMenu.gameObject.SetActive(IsOpen);

        //    if (Item != null && infoScreen != null)
        //    {
        //        infoScreen.transform.GetChild((int)InfoScreen.Energy).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = $"{Item.Buffer}/{Item.MaxBuffer}";
        //        infoScreen.transform.GetChild((int)InfoScreen.ProcessTime).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = $"{Item.ProcessTime}/{Item.MaxProcessTime}";
        //        infoScreen.transform.GetChild((int)InfoScreen.PowerConsume).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = $"{Item.PowerConsume}";
        //    }
        //}
    }

    public void CloseInterfaceItens()
    {
        //IsOpen = false;
        //title.text = "";
        //Item = null;
        //interfaceMenu.gameObject.SetActive(IsOpen);
    }

    public void ToggleWindowsInformation(GameObject infoScreen)
    {
        //if (!infoScreen.activeSelf)
        //{
        //    MainScreen.InterfaceMenu.Inf = infoScreen;
        //    infoScreen.SetActive(true);
        //}
        //else
        //{
        //    infoScreen.transform.GetChild((int)InfoScreen.Energy).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = "";
        //    infoScreen.transform.GetChild((int)InfoScreen.ProcessTime).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = "";
        //    infoScreen.transform.GetChild((int)InfoScreen.PowerConsume).GetChild(((int)ItemType.Value)).GetComponent<Text>().text = "";

        //    this.infoScreen = null;
        //    infoScreen.SetActive(false);
        //}
    }

    #endregion Machines
}