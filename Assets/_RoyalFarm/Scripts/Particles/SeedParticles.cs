using System.Collections.Generic;
using UnityEngine;

namespace _RoyalFarm.Scripts.Particles
{
    public class SeedParticles : MonoBehaviour
    {
        private ParticleSystem particleSystem;

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        private void OnParticleCollision(GameObject other)
        {
            List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        
            int collisionAmount = particleSystem.GetCollisionEvents(other, collisionEvents);
        
            Vector3[] collisionPositions = new Vector3[collisionAmount];

            for (int i = 0; i < collisionAmount; i++)
            {
                collisionPositions[i] = collisionEvents[i].intersection;
            }
        
            ParticleEvents.Instance.onSeedsCollided?.Invoke(collisionPositions);
        }
    }
}