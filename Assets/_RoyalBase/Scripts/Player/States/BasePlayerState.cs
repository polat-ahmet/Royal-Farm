
namespace _RoyalBase.Scripts.Player.States
{
    public abstract class BasePlayerState
    {
        protected PlayerStateMachine _stateMachine;

        public BasePlayerState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        internal virtual void Initialize()
        {
        }
        
        public abstract void Enter();
        public abstract void Exit();
        
        
        internal virtual void Dispose()
        {
        }
    }
}