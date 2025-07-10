using _RoyalFarm.Scripts.InputSystem.Data;
using UnityEngine;

namespace _RoyalFarm.Scripts.InputSystem
{
    public class MobileJoystickController : MonoBehaviour
    {
        [SerializeField] private RectTransform joystickOutline;
        [SerializeField] private RectTransform joystickKnob;
    
        private Vector3 _clickedPos;
        private Vector3 _moveVector;
    
        // private float moveFactor = Screen.width / 2;

        private void Start()
        {
            InputRelesedCallback();
        }

        internal void ClickedOnJoystickZoneCallback(Vector3 clickedPos)
        {
            _clickedPos = clickedPos;
            joystickOutline.position = _clickedPos;
            joystickOutline.gameObject.SetActive(true);
        }
        
        internal void InputRelesedCallback()
        {
            joystickOutline.gameObject.SetActive(false);
        
            _moveVector = Vector3.zero;
            _clickedPos = Vector3.zero;
        }

        internal void ControlJoystick(Vector3 currentPos)
        {
            Vector3 direction = currentPos - _clickedPos;
        
            // float moveMagnitude = direction.magnitude * moveFactor / Screen.width;
            float moveMagnitude = direction.magnitude;
            moveMagnitude = Mathf.Min(moveMagnitude, joystickOutline.rect.width / 2);
        
            _moveVector = direction.normalized * moveMagnitude;
        
            Vector3 targetPos = _clickedPos + _moveVector;
            joystickKnob.position = targetPos;
            
            Debug.Log("Move Vector: " + _moveVector);
            InputEvents.Instance.onInputDragged?.Invoke(new InputParams()
            {
                MoveVector = _moveVector,
            });
        }
    }
}
