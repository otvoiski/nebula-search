using Assets.Script.Data.Enum;
using Assets.Script.Data.Model;
using Assets.Script.Enumerator;
using Assets.Script.Util;
using Assets.Script.View.Model;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Assets.Script.View.Service
{
    public class BuilderScreenService : MonoBehaviour
    {
        public BuildScreenModel BuildScreen { get; private set; }
        [SerializeField] private bool IsReadyToSelect;
        [SerializeField] private bool IsReadyToAccept;
        [SerializeField] private bool IsReadyToConstruction;
        [SerializeField] private bool IsBuilding;

        /// <summary>
        /// Setup BuildScreenService
        /// </summary>
        /// <param name="buildScreen"></param>
        public void Setup(BuildScreenModel buildScreen)
        {
            BuildScreen = buildScreen;

            IsReadyToAccept = false;
            IsReadyToConstruction = false;
            IsReadyToSelect = false;
            IsBuilding = false;

            LoadingMenuList();
        }

        /// <summary>
        /// Load menu list from resources objects
        /// </summary>
        private void LoadingMenuList()
        {
            foreach (var category in System.Enum.GetValues(typeof(CategoryItemEnum)).Cast<CategoryItemEnum>())
            {
                var itemMenuButton = Instantiate(
                    Resources.Load<GameObject>("Prefabs/UI/MainScreen/BuildScreen/BuildMenu/BuildMenuItem"),
                    BuildScreen.BuildMenu.transform);
                itemMenuButton.transform.GetChild(0)
                    .GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>($"Icons/{category.ToString().ToLower()}");
                itemMenuButton.name = category.ToString();

                itemMenuButton.GetComponent<Button>().onClick.AddListener(delegate { ToggleBuildList(category); });
            }
        }

        /// <summary>
        /// Togle building variable
        /// </summary>
        public bool ToggleBuildMenu(bool isBuilding)
        {
            IsBuilding = isBuilding;

            return isBuilding;

            //IsBuilding = !IsBuilding;
            //return IsBuilding;
        }

        /// <summary>
        /// When the player press B
        /// </summary>
        /// <param name="isBuilding"></param>
        public void ToggleWindowsBuild()
        {
            // Open and close windows
            ToggleWindows();

            // Key commands of this interface
            KeyCommands();

            // Movement of transform item when user select item
            MovementItem();
        }

        /// <summary>
        /// Move item selected
        /// </summary>
        private void MovementItem()
        {
            if (IsBuilding && IsReadyToConstruction && BuildScreen.SelectedItem != null)
            {
                BuildScreen.SelectedItem.transform.position = Utilities.GetPositionGridFromScreenPoint(1);
            }
        }

        /// <summary>
        /// Manager windows if open or not
        /// </summary>
        private void ToggleWindows()
        {
            // BuildMenu
            BuildScreen.gameObject.SetActive(IsBuilding);
            BuildScreen.BuildMenu.gameObject.SetActive(IsBuilding);

            //BuildList
            BuildScreen.BuildList.gameObject.SetActive(IsBuilding && IsReadyToSelect);

            //InfoScreen
            BuildScreen.InfoScreen.gameObject.SetActive(IsBuilding && IsReadyToSelect && IsReadyToAccept);
        }

        /// <summary>
        /// Key commands
        /// </summary>
        private void KeyCommands()
        {
            var kb = InputSystem.GetDevice<Keyboard>();

            if (Input.GetKeyDown(KeyCode.Mouse0) && IsBuilding && IsReadyToConstruction)
            {
                if (!CanConstruct())
                {
                    Toast.Message(ToastType.Error, "Falha ao construir", "Você não pode construir aqui!");
                    return;
                }

                // TODO: Remove necessary itens from inventory of player.

                Instantiate(BuildScreen.SelectedItem, GameObject.Find("Map").transform)
                    .SetActive(true);

                if (BuildScreen.SelectedItem != null && IsReadyToConstruction)
                    Destroy(BuildScreen.SelectedItem);

                BuildScreen.SelectedItem = null;

                IsReadyToConstruction = false;
                IsReadyToAccept = false;
                IsReadyToSelect = false;
            }

            if (kb.escapeKey.wasPressedThisFrame && IsBuilding)
            {
                if (BuildScreen.SelectedItem != null && IsReadyToConstruction)
                    Destroy(BuildScreen.SelectedItem);

                BuildScreen.SelectedItem = null;

                IsReadyToConstruction = false;
                IsReadyToSelect = false;
                IsReadyToAccept = false;
                IsBuilding = false;
            }
        }

        private bool CanConstruct()
        {
            var r = true;
            foreach (var item in Utilities.GetItemsFromRayCast<GameObject>(BuildScreen.SelectedItem.transform, .10f))
            {
                if (item != null)
                {
                    r = false;
                    break;
                }
            }

            return r;
        }

        /// <summary>
        /// When player click the buton on BuildList
        /// </summary>
        /// <param name="gameObject"></param>
        public void AcceptToBuildMoveTransformSelectedItem()
        {
            BuildScreen.SelectedItem = Instantiate(BuildScreen.SelectedItem, GameObject.Find("GAME HANDLER").transform);
            BuildScreen.SelectedItem.SetActive(true);

            IsReadyToConstruction = true;
            IsReadyToSelect = false;
            IsReadyToAccept = false;
        }

        /// <summary>
        /// Create item in world later user accept to created
        /// </summary>
        /// <param name="gameObject"></param>
        public void ItemSelectedToBuild(GameObject gameObject)
        {
            IsReadyToAccept = !IsReadyToAccept;
            BuildScreen.SelectedItem = gameObject;
        }

        /// <summary>
        /// Update screen to build list
        /// </summary>
        /// <param name="enumerator"></param>
        public bool ToggleBuildList(CategoryItemEnum enumerator)
        {
            IsReadyToSelect = !IsReadyToSelect;
            IsReadyToAccept = false;

            var list = BuildScreen.BuildList.transform.GetChild(0); // <-- List
            var buildListItem = Resources.Load<GameObject>("Prefabs/UI/MainScreen/BuildScreen/BuildList/BuildListItem");

            // reset childs
            foreach (Transform child in list.transform)
            {
                if (child != null)
                    Destroy(child.gameObject);
            }

            if (IsReadyToSelect)
            {
                switch (enumerator)
                {
                    case CategoryItemEnum.Generator:
                        foreach (var item in GameHandler.Itens[$"{enumerator}"] as IList<GeneratorService>)
                        {
                            var button = FillItemBuildList(item.type, Instantiate(buildListItem, list));
                            button.onClick.AddListener(delegate { ItemSelectedToBuild(item.gameObject); });
                        }
                        break;

                    case CategoryItemEnum.Machine:
                        foreach (var item in GameHandler.Itens[$"{enumerator}"] as IList<MachineService>)
                        {
                            var button = FillItemBuildList(item.type, Instantiate(buildListItem, list));
                            button.onClick.AddListener(delegate { ItemSelectedToBuild(item.gameObject); });
                        }
                        break;

                    case CategoryItemEnum.Wire:
                        foreach (var item in GameHandler.Itens[$"{enumerator}"] as IList<WireService>)
                        {
                        }
                        break;

                    case CategoryItemEnum.Gas:
                        foreach (var item in GameHandler.Itens[$"{enumerator}"] as IList<GasService>)
                        {
                        }
                        break;

                    default:
                        break;
                }
            }

            list.gameObject.SetActive(IsReadyToSelect);
            Button FillItemBuildList(CategoryItemModel item, GameObject i)
            {
                if (item != null)
                {
                    i.name = item.title;

                    i.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
                    i.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.title;
                    return i.GetComponent<Button>();
                }

                return default;
            }
            return IsReadyToSelect;
        }
    }
}