using _RoyalFarm.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace _RoyalFarm.Scripts.Player
{
    public class PlayerEvents : MonoSingleton<PlayerEvents>
    {
        public UnityAction<bool> onMoveConditionChanged = delegate { };
    }
}