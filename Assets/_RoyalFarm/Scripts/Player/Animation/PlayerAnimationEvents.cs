using UnityEngine;

namespace _RoyalFarm.Scripts.Player.Animation
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        [SerializeField] private ParticleSystem seedParticles;
        
        private void PlaySeedParticles()
        {
            seedParticles.Play();
        }
    }
}