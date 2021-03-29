using Assets.Script.Data.Enum;
using Assets.Script.Data.Model;
using Assets.Script.Enumerator;
using Assets.Script.Util;
using Assets.Script.View.Model;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.View.Service
{
    public class BuilderScreenService : MonoBehaviour
    {
        public BuildScreenModel BuildScreen { get; private set; }

        [SerializeField] private bool _isReadyToSelect;
        [SerializeField] private bool _isReadyToAccept;
        [SerializeField] private bool _isReadyToConstruction;
        [SerializeField] private bool _isBuilding;

        private InputMaster _input;

        public void Awake()
        {
            _input = new InputMaster();

            _input.BuildMode.ClickToContruct.performed += _ => ClickToConstruct();
            _input.BuildMode.EscapeBuildMenu.performed += _ => EscapeFromBuildMode();
            _input.BuildMode.ToggleBuildMenu.performed += _ => ToggleBuildMenu();
        }

        /// <summary>
        /// Setup BuildScreenService
        /// </summary>
        /// <param name="buildScreen"></param>
        public void Setup(BuildScreenModel buildScreen)
        {
            BuildScreen = buildScreen;

            _isReadyToAccept = false;
            _isReadyToConstruction = false;
            _isReadyToSelect = false;
            _isBuilding = false;

            LoadingMenuList();
        }

        public void Update()
        {
            //BuildList
            BuildScreen.BuildList.gameObject.SetActive(_isBuilding && _isReadyToSelect);

            //InfoScreen
            BuildScreen.InfoScreen.gameObject.SetActive(_isBuilding && _isReadyToSelect && _isReadyToAccept);

            MovementItem();
        }

        /// <summary>
        /// Toggle building variable
        /// </summary>
        public void ToggleBuildMenu()
        {
            if (!BuildScreen.BuildMenu.gameObject.activeSelf && !ViewHandler.IsOpen)
            {
                _isBuilding = true;

                _isReadyToSelect = false;
                _isReadyToAccept = false;
                _isReadyToConstruction = false;

                ViewHandler.IsOpen = true;
                BuildScreen.BuildMenu.gameObject.SetActive(true);

                BuildScreen.BuildList.gameObject.SetActive(false);
                BuildScreen.InfoScreen.gameObject.SetActive(false);
            }
            else
            {
                if (BuildScreen.BuildMenu.gameObject.activeSelf && ViewHandler.IsOpen)
                {
                    _isBuilding = false;

                    _isReadyToSelect = false;
                    _isReadyToAccept = false;
                    _isReadyToConstruction = false;

                    ViewHandler.IsOpen = false;
                    BuildScreen.BuildMenu.gameObject.SetActive(false);

                    BuildScreen.BuildList.gameObject.SetActive(false);
                    BuildScreen.InfoScreen.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Escape of Build mode
        /// </summary>
        private void EscapeFromBuildMode()
        {
            if (_isBuilding || _isReadyToConstruction || _isReadyToSelect || _isReadyToAccept)
            {
                if (BuildScreen.SelectedItem != null && _isReadyToConstruction)
                    Destroy(BuildScreen.SelectedItem);

                BuildScreen.SelectedItem = null;

                _isReadyToConstruction = false;
                _isReadyToSelect = false;
                _isReadyToAccept = false;
                _isBuilding = false;

                BuildScreen.BuildMenu.gameObject.SetActive(false);
                BuildScreen.BuildList.gameObject.SetActive(false);
                BuildScreen.InfoScreen.gameObject.SetActive(false);
            }
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
        /// Move item selected
        /// </summary>
        private void MovementItem()
        {
            if (_isBuilding && _isReadyToConstruction && BuildScreen.SelectedItem != null)
            {
                BuildScreen.SelectedItem.transform.position = Utilities.GetMousePositionInGridPosition(1);
            }
        }

        /// <summary>
        /// When user click for instance item
        /// </summary>
        private void ClickToConstruct()
        {
            if (_isReadyToConstruction)
            {
                if (!CanConstruct())
                {
                    Toast.Message(
                        ToastType.Error,
                        Locate.Translate["BuildMode"]["CantConstructTitle"],
                        Locate.Translate["BuildMode"]["CantConstruct"]);
                    return;
                }

                // TODO: Remove necessary items from inventory of player.

                Instantiate(BuildScreen.SelectedItem, GameObject.Find("Map").transform)
                    .SetActive(true);

                if (BuildScreen.SelectedItem != null && _isReadyToConstruction)
                    Destroy(BuildScreen.SelectedItem);

                BuildScreen.SelectedItem = null;

                _isReadyToConstruction = false;
                _isReadyToAccept = false;
                _isReadyToSelect = false;
            }
        }

        /// <summary>
        /// Check collision, impossibility to construct
        /// </summary>
        /// <returns></returns>
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
        /// When player click the Button on BuildList
        /// </summary>
        public void AcceptToBuildMoveTransformSelectedItem()
        {
            BuildScreen.SelectedItem = Instantiate(BuildScreen.SelectedItem, GameObject.Find("GAME HANDLER").transform);
            BuildScreen.SelectedItem.SetActive(true);

            _isReadyToConstruction = true;
            _isBuilding = true;
            _isReadyToSelect = false;
            _isReadyToAccept = false;
        }

        /// <summary>
        /// Create item in world later user accept to created
        /// </summary>
        /// <param name="instance"></param>
        public void ItemSelectedToBuild(GameObject instance)
        {
            _isReadyToAccept = !_isReadyToAccept;
            BuildScreen.SelectedItem = instance;
        }

        /// <summary>
        /// Update screen to build list
        /// </summary>
        /// <param name="enumerator"></param>
        public bool ToggleBuildList(CategoryItemEnum enumerator)
        {
            _isReadyToSelect = !_isReadyToSelect;
            _isReadyToAccept = false;

            var list = BuildScreen.BuildList.transform.GetChild(0); // <-- List
            var buildListItem = Resources.Load<GameObject>("Prefabs/UI/MainScreen/BuildScreen/BuildList/BuildListItem");

            // reset child
            foreach (Transform child in list.transform)
            {
                if (child != null)
                    Destroy(child.gameObject);
            }

            if (_isReadyToSelect)
            {
                switch (enumerator)
                {
                    case CategoryItemEnum.Generator:
                        foreach (var item in (IList<GeneratorService>)GameHandler.Itens[$"{enumerator}"])
                        {
                            var button = FillItemBuildList(item.type, Instantiate(buildListItem, list));
                            button.onClick.AddListener(delegate { ItemSelectedToBuild(item.gameObject); });
                        }
                        break;

                    case CategoryItemEnum.Machine:
                        foreach (var item in (IList<MachineService>)GameHandler.Itens[$"{enumerator}"])
                        {
                            var button = FillItemBuildList(item.type, Instantiate(buildListItem, list));
                            button.onClick.AddListener(delegate { ItemSelectedToBuild(item.gameObject); });
                        }
                        break;

                    case CategoryItemEnum.Wire:
                        foreach (var item in (IList<WireService>)GameHandler.Itens[$"{enumerator}"])
                        {
                            var button = FillItemBuildList(item.type, Instantiate(buildListItem, list));
                            button.onClick.AddListener(delegate { ItemSelectedToBuild(item.gameObject); });
                        }
                        break;

                    case CategoryItemEnum.Gas:
                        foreach (var item in (IList<GasService>)GameHandler.Itens[$"{enumerator}"])
                        {
                            var button = FillItemBuildList(item.type, Instantiate(buildListItem, list));
                            button.onClick.AddListener(delegate { ItemSelectedToBuild(item.gameObject); });
                        }
                        break;

                    default:
                        break;
                }
            }

            list.gameObject.SetActive(_isReadyToSelect);

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
            return _isReadyToSelect;
        }

        public void OnEnable()
        {
            _input.BuildMode.Enable();
        }

        public void OnDisable()
        {
            _input.BuildMode.Disable();
        }
    }
}