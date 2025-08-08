using UnityEngine;

namespace _RoyalBase.Scripts.Player.States
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

        public override void Exit()
        {
            Debug.Log("Exited IdleState");
        }
    }
}