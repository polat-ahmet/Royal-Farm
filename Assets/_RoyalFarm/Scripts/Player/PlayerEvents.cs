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
        public UnityAction<PlayerAnimationStates> onChangePlayerAnimationState = delegate { };
        public UnityAction<PlayerAnimationLayers> onEnablePlayerAnimationLayer = delegate { };
        public UnityAction<PlayerAnimationLayers> onDisablePlayerAnimationLayer = delegate { };
        
        public UnityAction onSeedingAnimationEventTriggered = delegate { };
        
        public UnityAction<PlayerStateTypes> onChangePlayerState = delegate { };
        
        public UnityAction<bool> onMoveConditionChanged = delegate { };
        
        public UnityAction<CropField> onCropFieldEntered = delegate { };
        public UnityAction<CropField> onCropFieldExited = delegate { };
        
    }
}