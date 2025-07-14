using UnityEngine;

namespace _RoyalFarm.Scripts.Player.Commands.Data
{
    [CreateAssetMenu(fileName = "SeedingActionSO", menuName = "Royal Farm/SeedingActionSO", order = 0)]
    public class SeedingActionSO : ScriptableObject
    {
        public SeedingActionData Data;
    }
}