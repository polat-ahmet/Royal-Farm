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
            // List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
            //
            // int collisionAmount = _particleSystem.GetCollisionEvents(other, collisionEvents);
            //
            // Vector3[] collisionPositions = new Vector3[collisionAmount];
            //
            // for (int i = 0; i < collisionAmount; i++)
            // {
            //     collisionPositions[i] = collisionEvents[i].intersection;
            // }
            //
            // Debug.Log("Particle Collision");
            // ParticleEvents.Instance.onSeedsCollidedPositions?.Invoke(collisionPositions);
        }
    }
}