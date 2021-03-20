using Assets.Script.Enumerator;
using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject[] Itens;

    private void Start()
    {
        Locate.LoadLocate(Language.BR);

        LoadItens();
    }

    private void LoadItens()
    {
        throw new NotImplementedException();
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