using Assets.Script.Enumerator;
using Assets.Script.Util;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool IsBuilding { get; set; }

    private UIManager uiManager;

    public static GameObject itemSelectedToBuild;

    private void Awake()
    {
        uiManager = GameObject.Find("GAME HANDLER").GetComponent<UIManager>();
    }

    private void Start()
    {
        Locate.LoadLocate(Language.BR);
    }

    private void Update()
    {
        KeyEvents();
        Windows();
    }

    private void Windows()
    {
        uiManager.ToggleWindowsBuild(IsBuilding);
    }

    private void KeyEvents()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Toast.Message(ToastType.Success, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.X)) Toast.Message(ToastType.Warning, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.C)) Toast.Message(ToastType.Error, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.V)) Toast.Message(ToastType.Info, "Teste", "Menssage teste!");

        if (Input.GetKeyDown(KeyCode.B) && !uiManager.IsOpen) IsBuilding = !IsBuilding;
    }
}