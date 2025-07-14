using System;
using _RoyalFarm.Scripts.Crop;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerStateMachine
    {
        private PlayerState _state;
        
        public PlayerState State { get => _state;}
        
        //TODO change to states dict, create in runtime
        private PlayerIdleState _idleState;
        private PlayerSeedingState _seedingState;
        
        internal void Initialize()
        {
            _idleState = new PlayerIdleState(this);
            _seedingState = new PlayerSeedingState(this);
            
            _state = _idleState;
            
            PlayerEvents.Instance.onCropFieldExited += OnCropFieldExited;
            PlayerEvents.Instance.onCropFieldEntered += OnCropFieldEntered;
            
            _idleState.Initialize();
            _seedingState.Initialize();
        }
        
        private void OnCropFieldEntered(CropField cropField)
        {
            _state.OnCropFieldEntered(cropField);
        }
        
        private void OnCropFieldExited(CropField cropField)
        {
            _state.OnCropFieldExited(cropField);
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
            PlayerEvents.Instance.onCropFieldEntered -= OnCropFieldEntered;
            PlayerEvents.Instance.onCropFieldExited -= OnCropFieldExited;
            
            _idleState.Dispose();
            _seedingState.Dispose();
        }
    }
}