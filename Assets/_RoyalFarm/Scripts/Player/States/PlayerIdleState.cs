using _RoyalFarm.Scripts.Crop;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            PlayerEvents.Instance.onCropFieldEntered += OnCropFieldEntered;
        }

        private void OnCropFieldEntered(CropField arg0)
        {
            _stateMachine.ChangeState(PlayerStateTypes.Seeding);
        }

        public override void Enter()
        {
            Debug.Log("Entered IdleState");
        }

        public override void Exit()
        {
            Debug.Log("Exited IdleState");
        }

        public override void Dispose()
        {
            PlayerEvents.Instance.onCropFieldEntered -= OnCropFieldEntered;
        }
    }
}