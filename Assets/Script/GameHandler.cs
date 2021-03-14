using Assets.Script.Enumerator;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [Header("Camera Info")] public Vector3 alinhamento;
    public CameraFollow cameraFollow;

    [Header("Player Info")] public Transform playerTransform;
    public PlayerData playerData;

    private void Awake()
    {
        Locate.LoadLocate(Language.BR);
    }

    private void Start()
    {
        cameraFollow.Setup(() => playerTransform.position, alinhamento);
        playerData.Setup(() => playerTransform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Toast.Message(ToastType.Success, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.X)) Toast.Message(ToastType.Warning, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.C)) Toast.Message(ToastType.Error, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.V)) Toast.Message(ToastType.Info, "Teste", "Menssage teste!");
    }
}