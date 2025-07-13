using _RoyalFarm.Scripts.Crop;
using _RoyalFarm.Scripts.Player.Animation;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerSeedingState : PlayerState
    {
        public PlayerSeedingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            PlayerEvents.Instance.onCropFieldExited += OnCropFieldExited;
        }

        private void OnCropFieldExited(CropField arg0)
        {
            _stateMachine.ChangeState(PlayerStateTypes.Idle);
        }

        public override void Enter()
        {
            Debug.Log("Entered Seeding State");
            PlayerEvents.Instance.onEnablePlayerAnimationLayer?.Invoke(PlayerAnimationLayers.Seed);
        }

        public override void Exit()
        {
            Debug.Log("Exited Seeding State");
            PlayerEvents.Instance.onDisablePlayerAnimationLayer?.Invoke(PlayerAnimationLayers.Seed);
        }

        public override void Dispose()
        {
            PlayerEvents.Instance.onCropFieldExited -= OnCropFieldExited;
        }
    }
}