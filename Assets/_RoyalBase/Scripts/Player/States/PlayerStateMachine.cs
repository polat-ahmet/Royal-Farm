using System;

namespace _RoyalBase.Scripts.Player.States
{
    public class PlayerStateMachine
    {
        private BasePlayerState _state;
        public BasePlayerState State { get => _state;}
        
        //TODO change to states dict, create in runtime
        private PlayerIdleState _idleState;
        
        internal void Initialize()
        {
            _idleState = new PlayerIdleState(this);
            
            _state = _idleState;
            
            _idleState.Initialize();
        }
        
        internal void TransitionToState(PlayerStateType newState)
        {
            _state.Exit();

            switch (newState)
            {
                case PlayerStateType.Idle:
                    _state = _idleState;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
            
            _state.Enter();
            PlayerEvents.Instance.onChangePlayerState(newState);
        }

        internal void Dispose()
        {
            _idleState.Dispose();
        }
    }
}