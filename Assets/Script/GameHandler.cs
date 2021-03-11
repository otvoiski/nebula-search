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
    private float zoom = 60f;

    private void Awake()
    {
        Locate.LoadLocate(Language.BR);
    }

    private void Start()
    {
        var uiManager = gameObject.AddComponent<UIManager>();

        uiManager.Setup();
        cameraFollow.Setup(() => playerTransform.position, () => zoom, alinhamento);
        playerData.Setup(() => playerTransform);

        LoadGenerators(uiManager);
        LoadMachines(uiManager);
    }

    private static void LoadMachines(UIManager uiManager)
    {
        List<GameObject> machines = GameObject
            .FindGameObjectsWithTag("Machine")
            .ToList();

        foreach (var machine in machines)
        {
            machine
                .GetComponent<Machine>()
                .Setup(() => uiManager);
        }
    }

    private static void LoadGenerators(UIManager uiManager)
    {
        List<GameObject> generators = GameObject
            .FindGameObjectsWithTag("Generator")
            .ToList();
        foreach (var generator in generators)
        {
            generator
                .GetComponent<Generator>()
                .Setup(uiManager);
        }
    }

    private void Update()
    {
        HandleZoomButtons();
    }

    private void HandleZoomButtons()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ZoomOut();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ZoomIn();
        }
    }

    private void ZoomIn()
    {
        zoom -= 40f;
        if (zoom < 40f) zoom = 40f;
        cameraFollow.SetCameraZoom(zoom);
    }

    private void ZoomOut()
    {
        zoom += 40f;
        if (zoom > 200f) zoom = 200f;
        cameraFollow.SetCameraZoom(zoom);
    }
}