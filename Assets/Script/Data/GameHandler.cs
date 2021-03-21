using Assets.Script.Enumerator;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public InputMaster _input;
    public static GameObject[] Itens;

    private void Awake()
    {
        _input = new InputMaster();

        _input.ToastTest.ShowToast.performed += _ => Toast.Message(ToastType.Success, "Teste", "Menssage teste!");
    }

    private void Start()
    {
        Locate.LoadLocate(Language.BR);

        LoadItens();
    }

    private void LoadItens()
    {
        Itens = Resources.LoadAll<GameObject>("Itens");
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}