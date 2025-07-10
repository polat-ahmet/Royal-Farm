using _RoyalFarm.Scripts.InputSystem.Data;
using _RoyalFarm.Scripts.Utilities;
using UnityEngine.Events;

namespace _RoyalFarm.Scripts.InputSystem
{
    public class InputEvents : MonoSingleton<InputEvents>
    {
        public UnityAction<bool> onChangeInputState = delegate { };
        public UnityAction onInputTaken = delegate { };
        public UnityAction<InputParams> onInputDragged = delegate { };
        public UnityAction onInputReleased = delegate { };
    }
}