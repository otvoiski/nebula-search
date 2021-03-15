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

    public GameObject activeItemToCreate;

    private void Start()
    {
        Locate.LoadLocate(Language.BR);

        cameraFollow.Setup(() => playerTransform.position, alinhamento);
        playerData.Setup(() => playerTransform);
    }

    public void CreateItemInWorld(GameObject gameObject)
    {
        activeItemToCreate = gameObject;
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
            activeItemToCreate.SetActive(IsBuilding);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 15f))
            {
                if (activeItemToCreate != null)
                {
                    activeItemToCreate.transform.position = new Vector3(
                    Mathf.CeilToInt(hit.point.x) - 0.5f,
                    0,
                    Mathf.CeilToInt(hit.point.z) - 0.5f);
                }

                //TODO: Change sprite color if possible to position item
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(activeItemToCreate);
                }
            }
        }
        else
        {
            uiManager.ToggleWindowsBuild(IsBuilding);
            activeItemToCreate.SetActive(IsBuilding);
        }
    }
}