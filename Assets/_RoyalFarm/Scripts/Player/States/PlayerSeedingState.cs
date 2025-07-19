using _RoyalFarm.Scripts.Crop;
using _RoyalFarm.Scripts.Farming;
using _RoyalFarm.Scripts.Particles;
using _RoyalFarm.Scripts.Player.Animation;
using _RoyalFarm.Scripts.Player.Commands;
using _RoyalFarm.Scripts.Player.Commands.Data;
using JetBrains.Annotations;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerSeedingState : BasePlayerState
    {
        [CanBeNull] private SeedParticles _seedParticles;
        private SeedingActionData _seedingActionData;

        public PlayerSeedingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            _seedParticles = null;
        }

        internal override void Initialize()
        {
            PlayerEvents.Instance.onSeedingAnimationEventTriggered += OnSeedingAnimatiomEventTriggered;
            
            var go = ParticleEvents.Instance.onCreateParticleGameObject?.Invoke(ParticleType.Seeding);

            if (go != null)
            {
                _seedParticles = go.GetComponent<SeedParticles>();
            }

            _seedingActionData = Resources.Load<SeedingActionSO>("Data/SeedingActionSO").Data;
        }

        public override void Enter()
        {
            Debug.Log("Entered Seeding State");
            PlayerEvents.Instance.onEnablePlayerAnimationLayer?.Invoke(PlayerAnimationLayerType.Seed);
        }
        
        private void OnSeedingAnimatiomEventTriggered()
        {
            if (_seedParticles != null)
            {
                _seedParticles.Play();
            }

            var seedAction = new SeedAction(
                origin: _seedParticles.transform.position + Vector3.down,
                direction: _seedParticles.transform.forward,
                angle: _seedingActionData.Angle,
                radius: _seedingActionData.Radius,
                seedableMask: _seedingActionData.SeedableMask,
                visualize: true
            );

            seedAction.Execute();
        }

        internal override void OnCropFieldExited(CropField cropField)
        {
            _stateMachine.TransitionToState(PlayerStateType.Idle);
        }
        
        internal override void OnCropFieldStateChanged(CropField cropField, CropFieldStateType newCropFieldState)
        {
            if (newCropFieldState == CropFieldStateType.Seeded)
            {
                _stateMachine.TransitionToState(PlayerStateType.Idle);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exited Seeding State");
            PlayerEvents.Instance.onDisablePlayerAnimationLayer?.Invoke(PlayerAnimationLayerType.Seed);
        }

        internal override void Dispose()
        {
            PlayerEvents.Instance.onSeedingAnimationEventTriggered -= OnSeedingAnimatiomEventTriggered;
            base.Dispose();
        }
    }
}