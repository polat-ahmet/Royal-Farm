using _RoyalFarm.Scripts.Player.Enums;
using _RoyalFarm.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace _RoyalFarm.Scripts.Player
{
    public class PlayerEvents : MonoSingleton<PlayerEvents>
    {
        public UnityAction<PlayerAnimationStates> onChangePlayerAnimationState = delegate { };
        public UnityAction<bool> onMoveConditionChanged = delegate { };
    }
}