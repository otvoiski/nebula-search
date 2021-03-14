using Assets.Script.Enumerator;
using Assets.Script.Util;
using UnityEngine;

public class GameHandler : MonoBehaviourExtended
{
    [Header("Camera Info")] public Vector3 alinhamento;
    public CameraFollow cameraFollow;

    [Header("Player Info")] public Transform playerTransform;
    public PlayerData playerData;

    public static bool IsBuilding { get; set; }

    [Component]
    private UIManager uiManager;

    private void Start()
    {
        Locate.LoadLocate(Language.BR);

        cameraFollow.Setup(() => playerTransform.position, alinhamento);
        playerData.Setup(() => playerTransform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Toast.Message(ToastType.Success, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.X)) Toast.Message(ToastType.Warning, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.C)) Toast.Message(ToastType.Error, "Teste", "Menssage teste!");
        if (Input.GetKeyDown(KeyCode.V)) Toast.Message(ToastType.Info, "Teste", "Menssage teste!");

        if (Input.GetKeyDown(KeyCode.B) && !uiManager.IsOpen)
        {
            IsBuilding = !IsBuilding;
            Toast.Message(ToastType.Info, "Building", $"Building {IsBuilding}");
        }

        if (IsBuilding)
        {
            uiManager.ToggleWindowsBuild(IsBuilding);

            var ray = Utilities.GetRaycastHitFromScreenPoint();
            if (ray != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(ray.GetValueOrDefault().transform.name);
            }
        }
        else
        {
            uiManager.ToggleWindowsBuild(IsBuilding);
        }
    }
}