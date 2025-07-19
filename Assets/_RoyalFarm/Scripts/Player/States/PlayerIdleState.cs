using _RoyalFarm.Scripts.Crop;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerIdleState : BasePlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }
        
        public override void Enter()
        {
            Debug.Log("Entered IdleState");
        }
        
        internal override void OnCropFieldEntered(CropField cropField)
        {
            if (cropField.State == CropFieldStateType.Empty)
            {
                _stateMachine.TransitionToState(PlayerStateType.Seeding);
            }
        }

        internal override void OnCropFieldStateChanged(CropField cropField, CropFieldStateType newCropFieldState)
        {
            if (newCropFieldState == CropFieldStateType.Empty)
            {
                _stateMachine.TransitionToState(PlayerStateType.Seeding);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exited IdleState");
        }
    }
}