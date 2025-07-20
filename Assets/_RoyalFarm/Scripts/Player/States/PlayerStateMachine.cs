using System;
using _RoyalFarm.Scripts.Crop;
using _RoyalFarm.Scripts.Farming;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerStateMachine
    {
        private BasePlayerState _state;
        public BasePlayerState State { get => _state;}
        
        //TODO change to states dict, create in runtime
        private PlayerIdleState _idleState;
        private PlayerSeedingState _seedingState;
        
        private CropField _currentCropField;
        
        internal void Initialize()
        {
            _idleState = new PlayerIdleState(this);
            _seedingState = new PlayerSeedingState(this);
            
            _state = _idleState;
            
            _idleState.Initialize();
            _seedingState.Initialize();
            
            PlayerEvents.Instance.onCropFieldExited += OnCropFieldExited;
            PlayerEvents.Instance.onCropFieldEntered += OnCropFieldEntered;
            
            FarmingEvents.Instance.onCropFieldStateChanged += OnCropFieldStateChanged;
        }

        private void OnCropFieldStateChanged(CropField cropField, CropFieldStateType cropFieldState)
        {
            _state.OnCropFieldStateChanged(cropField, cropFieldState);
        }

        private void OnCropFieldEntered(CropField cropField)
        {
            if (_currentCropField != null || _currentCropField == cropField) return;
            
            Debug.Log($"OnCropFieldEntered {cropField}");
            _currentCropField = cropField;
            _state.OnCropFieldEntered(cropField);
        }
        
        private void OnCropFieldExited(CropField cropField)
        {
            if (_currentCropField == null || _currentCropField != cropField) return;
            
            Debug.Log($"OnCropFieldExited {cropField}");
            _currentCropField = null;
            _state.OnCropFieldExited(cropField);
        }

        internal void TransitionToState(PlayerStateType newState)
        {
            _state.Exit();

            switch (newState)
            {
                case PlayerStateType.Idle:
                    _state = _idleState;
                    break;
                case PlayerStateType.Seeding:
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
            
            PlayerEvents.Instance.onCropFieldEntered -= OnCropFieldEntered;
            PlayerEvents.Instance.onCropFieldExited -= OnCropFieldExited;
        }
    }
}