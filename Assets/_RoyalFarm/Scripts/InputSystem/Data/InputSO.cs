using UnityEngine;

namespace _RoyalFarm.Scripts.InputSystem.Data
{
    [CreateAssetMenu(fileName = "InputSO", menuName = "Royal Farm/InputSO", order = 0)]
    public class InputSO : ScriptableObject
    {
        public InputData Data;
    }
}