using System.Collections.Generic;
using UnityEngine;

namespace _RoyalFarm.Scripts.Particles
{
    public class SeedParticles : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void Play()
        {
            //TODO object pooling emit
            _particleSystem.Play();
        }

        
        
        private void OnParticleCollision(GameObject other)
        {
            
            // Debug.Log("Particle Collision");
            // ParticleEvents.Instance.onSeedsCollidedPositions?.Invoke(collisionPositions);
        }
    }
}