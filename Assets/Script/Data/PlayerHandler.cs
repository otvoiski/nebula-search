using Assets.Script.Util;
using Assets.Script.View;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.Data
{
    public class PlayerHandler : MonoBehaviour
    {
        private InputMaster _input;
        private ViewHandler _viewHandler;
        private Vector2 _move;
        private Vector3 _cameraOffset;

        [SerializeField] private float _speed;
        [SerializeField] private bool _cameraFollow;
        [SerializeField, Range(.01f, 1f)] private float _SmoothFactorCamera = .5f;
        [SerializeField] private bool _cameraLookAtPlayer;

        public void Awake()
        {
            // Load viewHandler
            _viewHandler = GameObject.Find(ViewHandler.NAME)
                .GetComponent<ViewHandler>();

            // default speed
            _speed = 10f;

            // Load inputSystem
            _input = new InputMaster();
            _input.Player.Inventory.performed += ToggleInventory;
            _input.Player.Movement.performed += _ => _move = _.ReadValue<Vector2>(); // Read Movement
            _input.Player.Movement.canceled += _ => _move = Vector2.zero;
        }

        private void Start()
        {
            _cameraOffset = Camera.main.transform.position - transform.position;
            _cameraFollow = true;
            _cameraLookAtPlayer = true;
        }

        private void Update()
        {
            PlayerMovement(_move);
            PlayerRotate();
        }

        private void LateUpdate()
        {
            if (_cameraFollow)
            {
                var pos = transform.position + _cameraOffset;
                var camera = Camera.main.transform;

                camera.position = Vector3.Lerp(camera.position, pos, _SmoothFactorCamera);
                if (_cameraLookAtPlayer)
                    camera.transform.LookAt(transform);
            }
        }

        private void PlayerRotate()
        {
            var position = Utilities.GetMousePositionToVector3Grid(1, LayerMask.GetMask("Grid"), true);
            transform.LookAt(position);
        }

        private void PlayerMovement(Vector2 move)
        {
            if (move != Vector2.zero)
            {
                var controller = GetComponent<CharacterController>();
                controller.Move(new Vector3(x: -move.x, y: 0, z: -move.y) * Time.deltaTime * _speed);
            }
        }

        public void ToggleInventory(InputAction.CallbackContext obj)
        {
            _viewHandler.ToggleInventory();
        }

        public void OnEnable()
        {
            _input.Player.Enable();
        }

        public void OnDisable()
        {
            _input.Player.Disable();
        }
    }
}