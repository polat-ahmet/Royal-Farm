using _RoyalFarm.Scripts.InputSystem.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _RoyalFarm.Scripts.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private MobileJoystickController _mobileJoystickController;
        
        
        [Header("Data")] 
        private InputData _data;
        
        [ShowInInspector] private bool _isAvailableForTouch;
        [ShowInInspector] private bool _isTouching;
        
        private void Awake()
        {
            // _data = GetInputData();
            // SendDataToController();
        }
        
        // private InputData GetInputData() => Resources.Load<InputSO>("Data/Input").Data;

        private void Start()
        {
            _isAvailableForTouch = true;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputEvents.Instance.onChangeInputState += OnChangeInputState;
        }

        private void OnChangeInputState(bool state)
        {
            _isAvailableForTouch = state;
        }


        public void ClickedOnJoystickZoneCallback()
        {
            if (!_isAvailableForTouch || _isTouching) return;
            _mobileJoystickController.ClickedOnJoystickZoneCallback(Input.mousePosition);
            _isTouching = true;
            InputEvents.Instance.onInputTaken?.Invoke();
        }

        private void Update()
        {
            if (!_isAvailableForTouch || !_isTouching) return;
            
            if (Input.GetMouseButtonUp(0))
            {
                _mobileJoystickController.InputRelesedCallback();
                _isTouching = false;
                InputEvents.Instance.onInputReleased?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                _mobileJoystickController.ControlJoystick(Input.mousePosition);
            }
        }

        private void OnDestroy()
        {
            UnSubscribeEvents();
        }
        
        private void UnSubscribeEvents()
        {
            InputEvents.Instance.onChangeInputState -= OnChangeInputState;
        }
    }
}