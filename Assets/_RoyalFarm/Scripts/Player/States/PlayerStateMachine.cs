using System;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerStateMachine
    {
        private PlayerState _state;
        
        public PlayerState State { get => _state;}
        
        private PlayerIdleState _idleState;
        private PlayerSeedingState _seedingState;
        
        internal void Initialize()
        {
            _idleState = new PlayerIdleState(this);
            _seedingState = new PlayerSeedingState(this);
            
            _state = _idleState;
        }

        internal void ChangeState(PlayerStateTypes newState)
        {
            _state.Exit();

            switch (newState)
            {
                case PlayerStateTypes.Idle:
                    _state = _idleState;
                    break;
                case PlayerStateTypes.Seeding:
                    _state = _seedingState;
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
            _seedingState.Dispose();
        }
    }
}