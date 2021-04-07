using Assets.Data.Enum;
using Assets.Data.Model;
using Assets.Data.Util;
using Assets.Data.Util.Toast;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Data.Service
{
    public class BuildScreenService : MonoBehaviour
    {
        [SerializeField] private bool _isOpen;
        private InputMaster _input;
        private Transform _build;
        private Transform _menu;
        private Transform _list;
        private Transform _info;
        private GameObject _menuItem;
        private GameObject _listItem;
        private GameObject _resourceItem;
        private GameObject _itemToConstruct;
        private Transform _gameHandler;
        private Transform _map;

        private void Awake()
        {
            _build = transform.Find("Build");
            _menu = transform.Find("Menu");
            _list = transform.Find("List");
            _info = transform.Find("Info");

            _input = new InputMaster();

            _input.BuildScreen.ToggleBuildScreen.performed += _ => ToggleBuildScreen();
            _input.BuildScreen.EscapeBuildScreen.performed += _ => CloseBuildScreen();
            _input.BuildScreen.ClickToConstruct.performed += _ => ClickToConstruct();
        }

        private void Start()
        {
            _menuItem = Resources.Load<GameObject>("Prefabs/UI/BuildScreen/Menu/Item/Item Variant");
            _listItem = Resources.Load<GameObject>("Prefabs/UI/BuildScreen/List/Item");
            _resourceItem = Resources.Load<GameObject>("Prefabs/UI/BuildScreen/Info/Top/Item");

            _gameHandler = GameObject.Find("GAME HANDLER").transform;
            _map = GameObject.Find("Map").transform;

            CloseBuildScreen();
        }

        private void ToggleBuildScreen()
        {
            try
            {
                switch (_build.gameObject.activeSelf)
                {
                    case false when !ViewHandler.IsOpen:
                        {
                            _build.gameObject.SetActive(true);
                            _menu.gameObject.SetActive(true);

                            ViewHandler.IsOpen = true;

                            // Load all items in menu
                            var allItems = Instantiate(_menuItem, _menu);
                            allItems.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Icons/All");
                            allItems.transform.Find("Text").GetComponent<TMP_Text>().text = "All items";
                            allItems.transform.GetComponent<Button>().onClick.AddListener(delegate { OpenList("All"); });

                            // Load category in menu
                            foreach (var item in GameHandler.Items)
                            {
                                var i = Instantiate(_menuItem, _menu);
                                i.transform.GetComponent<Button>().onClick.AddListener(delegate { OpenList(item.Key); }); // Item
                                i.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Icons/{item.Key}"); // Image
                                i.transform.Find("Text").GetComponent<TMP_Text>().text = item.Key + "s"; // Text
                            }

                            break;
                        }
                    case true when ViewHandler.IsOpen:
                        CloseBuildScreen();
                        break;
                }
            }
            catch (Exception e)
            {
                Toast.Exception(e);
            }
        }

        private void OpenList(string category)
        {
            try
            {
                Utilities.ResetChildTransform(_list);

                // Set info screen with false case user click again on list
                _info.gameObject.SetActive(false);

                if (category == "All")
                {
                    foreach (var item in GameHandler.Items)
                    {
                        foreach (var machine in item.Value)
                        {
                            var i = Instantiate(_listItem, _list);

                            i.GetComponent<Button>().onClick.AddListener(delegate { OpenInfo(machine); });
                            i.transform.Find("Text").GetComponent<TMP_Text>().text = machine.Title;
                            i.transform.Find("Image").GetComponent<Image>().sprite = machine.Icon;
                        }
                    }
                }
                else
                {
                    foreach (var machine in GameHandler.Items[category])
                    {
                        var i = Instantiate(_listItem, _list);

                        i.GetComponent<Button>().onClick.AddListener(delegate { OpenInfo(machine); });
                        i.transform.Find("Text").GetComponent<TMP_Text>().text = machine.Title;
                        i.transform.Find("Image").GetComponent<Image>().sprite = machine.Icon;
                    }
                }

                _list.gameObject.SetActive(true);
            }
            catch (Exception e)
            {
                Toast.Exception(e);
            }
        }

        private void OpenInfo(MachineModel machine)
        {
            try
            {
                // Change Title - TOP
                _info
                    .Find("Top")
                    .Find("Title")
                    .Find("Text")
                    .GetComponent<TMP_Text>()
                    .text = machine.Title;

                var resources = _info
                    .Find("Top")
                    .Find("Resources");

                // MID
                Utilities.ResetChildTransform(resources);

                foreach (var resource in machine.ResourcesToBuild)
                {
                    var i = Instantiate(_resourceItem, resources);

                    //i.transform.Find("Image") .GetComponent<Image>().sprite; // Get Icon from Material
                    i.transform.Find("Text").GetComponent<TMP_Text>().text = resource.Amount.ToString();
                }

                // Set the description info menu
                _info
                    .Find("Mid")
                    .Find("Description")
                    .Find("Text")
                    .GetComponent<TMP_Text>()
                    .text = machine.Description;

                // BOT
                // Info/Bot/Buttons/Build/Button
                _info
                    .Find("Bot")
                    .Find("Buttons")
                    .Find("Build")
                    .Find("Button")
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(delegate { ReadyToConstruct(machine); });

                // Show screen
                _info.gameObject.SetActive(true);
            }
            catch (Exception e)
            {
                Toast.Exception(e);
            }
        }

        private void ReadyToConstruct(MachineModel machine)
        {
            try
            {
                Utilities.ResetChildTransform(_gameHandler);

                // set menu off
                _menu.gameObject.SetActive(false);
                // set list off
                _list.gameObject.SetActive(false);
                // set info off
                _info.gameObject.SetActive(false);

                // instance item
                _itemToConstruct = Instantiate(machine.Prefab, _gameHandler);
                _itemToConstruct
                    .AddComponent<MachineService>()
                    .Type = machine;
            }
            catch (Exception e)
            {
                Toast.Exception(e);
            }
        }

        private void ClickToConstruct()
        {
            try
            {
                if (!_build || !ViewHandler.IsOpen || !_itemToConstruct) return;

                if (!CanConstruct())
                {
                    Toast.ShowToast(
                        ToastType.Error,
                        Locale.Translate["BuildScreen"]["CannotConstructTitle"],
                        Locale.Translate["BuildScreen"]["CannotConstruct"]);
                }

                Debug.Log("Construct");
                _itemToConstruct.transform.parent = _map;

                _menu.gameObject.SetActive(true);
                _list.gameObject.SetActive(false);
                _info.gameObject.SetActive(false);

                Utilities.ResetChildTransform(_list);

                _itemToConstruct = null;
                Utilities.ResetChildTransform(_gameHandler);
            }
            catch (Exception e)
            {
                Toast.Exception(e);
            }
        }

        private static bool CanConstruct()
        {
            try
            {
                var mouse = Utilities.GetGameObjectFromMousePosition();

                // Check if exist item on position mouse;
                if (mouse.name.Contains("default"))
                {
                    Debug.Log("Can construct");
                }
                else
                {
                    Debug.Log(mouse.name);
                    Debug.Log("Can't construct");
                }
                return false;
            }
            catch (Exception e)
            {
                Toast.Exception(e);
                return false;
            }
        }

        private void CloseBuildScreen()
        {
            try
            {
                _build.gameObject.SetActive(false);
                _menu.gameObject.SetActive(false);
                _list.gameObject.SetActive(false);
                _info.gameObject.SetActive(false);

                Utilities.ResetChildTransform(_menu);
                Utilities.ResetChildTransform(_list);

                _itemToConstruct = null;
                Utilities.ResetChildTransform(_gameHandler);

                ViewHandler.IsOpen = false;
            }
            catch (Exception e)
            {
                Toast.Exception(e);
            }
        }

        private void OnEnable()
        {
            _input.BuildScreen.Enable();
        }

        private void OnDisable()
        {
            _input.BuildScreen.Disable();
        }

        private void Update()
        {
            try
            {
                _isOpen = ViewHandler.IsOpen;

                if (_itemToConstruct != null)
                {
                    _itemToConstruct.transform.position = Utilities
                        .GetMousePositionToVector3Grid(-0.5f, LayerMask.GetMask(Utilities.GRID_LAYER), true);
                }
            }
            catch (Exception e)
            {
                Toast.Exception(e);
            }
        }
    }
}