using UnityEngine;

namespace _RoyalBase.Scripts.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "Royal Farm/PlayerSO", order = 0)]
    public class PlayerSO : ScriptableObject
    {
        public PlayerData Data;
    }
}