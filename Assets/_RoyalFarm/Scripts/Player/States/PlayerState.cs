namespace _RoyalFarm.Scripts.Player.States
{
    public abstract class PlayerState
    {
        protected PlayerStateMachine _stateMachine;
        public PlayerState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Dispose();
    }
}