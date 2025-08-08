using _RoyalBase.Scripts.Player.Animation;
using _RoyalBase.Scripts.Player.States;
using _RoyalFarm.Scripts.Utilities;
using UnityEngine.Events;

namespace _RoyalBase.Scripts.Player
{
    public class PlayerEvents : MonoSingleton<PlayerEvents>
    {
        public UnityAction<PlayerAnimationStateType> onChangePlayerAnimationState = delegate { };
        public UnityAction<PlayerAnimationLayerType> onEnablePlayerAnimationLayer = delegate { };
        public UnityAction<PlayerAnimationLayerType> onDisablePlayerAnimationLayer = delegate { };
        
        public UnityAction<PlayerStateType> onChangePlayerState = delegate { };
        
        public UnityAction<bool> onMoveConditionChanged = delegate { };
        
    }
}