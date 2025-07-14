using _RoyalFarm.Scripts.Crop;
using _RoyalFarm.Scripts.Particles;
using _RoyalFarm.Scripts.Player.Animation;
using _RoyalFarm.Scripts.Player.Commands;
using JetBrains.Annotations;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.States
{
    public class PlayerSeedingState : PlayerState
    {
        [CanBeNull] private SeedParticles _seedParticles;
        
        public PlayerSeedingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            _seedParticles = null;
        }

        internal override void Initialize()
        {
            PlayerEvents.Instance.onSeedingAnimationEventTriggered += OnSeedingAnimatiomEventTriggered;

            var go = ParticleEvents.Instance.onCreateParticleGameObject?.Invoke(ParticleType.Seeding);
            
            if (go != null)
                _seedParticles = go.GetComponent<SeedParticles>();
        }

        private void OnSeedingAnimatiomEventTriggered()
        {
            if (_seedParticles != null) _seedParticles.Play();

            var seedAction = new SeedGameplayAction();
            seedAction.Execute();
        }

        internal override void OnCropFieldExited(CropField arg0)
        {
            _stateMachine.ChangeState(PlayerStateTypes.Idle);
        }

        public override void Enter()
        {
            Debug.Log("Entered Seeding State");
            PlayerEvents.Instance.onEnablePlayerAnimationLayer?.Invoke(PlayerAnimationLayers.Seed);
        }

        public override void Exit()
        {
            Debug.Log("Exited Seeding State");
            PlayerEvents.Instance.onDisablePlayerAnimationLayer?.Invoke(PlayerAnimationLayers.Seed);
        }

        internal override void Dispose()
        {
            PlayerEvents.Instance.onSeedingAnimationEventTriggered -= OnSeedingAnimatiomEventTriggered;
            base.Dispose();
        }
    }
}