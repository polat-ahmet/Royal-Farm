using _RoyalFarm.Scripts.Crop;
using _RoyalFarm.Scripts.Player.Animation;
using _RoyalFarm.Scripts.Player.States;
using _RoyalFarm.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace _RoyalFarm.Scripts.Player
{
    public class PlayerEvents : MonoSingleton<PlayerEvents>
    {
        public UnityAction<PlayerAnimationStateType> onChangePlayerAnimationState = delegate { };
        public UnityAction<PlayerAnimationLayerType> onEnablePlayerAnimationLayer = delegate { };
        public UnityAction<PlayerAnimationLayerType> onDisablePlayerAnimationLayer = delegate { };
        
        public UnityAction onSeedingAnimationEventTriggered = delegate { };
        
        public UnityAction<PlayerStateType> onChangePlayerState = delegate { };
        
        public UnityAction<bool> onMoveConditionChanged = delegate { };
        
        public UnityAction<CropField> onCropFieldEntered = delegate { };
        public UnityAction<CropField> onCropFieldExited = delegate { };
        
    }
}