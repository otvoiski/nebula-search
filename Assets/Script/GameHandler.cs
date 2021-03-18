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

    public void CreateItemInWorld(GameObject gameObject)
    {
        itemSelectedToBuild = Instantiate(gameObject, this.gameObject.transform);
        itemSelectedToBuild.SetActive(true);
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
            //itemSelectedToBuild.SetActive(IsBuilding);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 15f))
            {
                if (itemSelectedToBuild != null)
                {
                    itemSelectedToBuild.transform.position = new Vector3(
                    Mathf.CeilToInt(hit.point.x),
                    0,
                    Mathf.CeilToInt(hit.point.z));
                }

                //TODO: Change sprite color if possible to position item
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //TODO: Check if have itens on inventory
                    if (itemSelectedToBuild != null)
                        Instantiate(itemSelectedToBuild);
                }
            }
        }
        else
        {
            uiManager.ToggleWindowsBuild(IsBuilding);
            if (itemSelectedToBuild != null)
                Destroy(itemSelectedToBuild);
        }
    }
}