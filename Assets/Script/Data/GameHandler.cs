using Assets.Script.Enumerator;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool IsBuilding { get; set; }

    public static GameObject itemSelectedToBuild;

    private void Start()
    {
        Locate.LoadLocate(Language.BR);
    }

    private void Update()
    {
        KeyEvents();
    }

    private void KeyEvents()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Toast.Message(ToastType.Success, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.X)) Toast.Message(ToastType.Warning, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.C)) Toast.Message(ToastType.Error, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.V)) Toast.Message(ToastType.Info, "Teste", "Menssage teste!");
    }
}