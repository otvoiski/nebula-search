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