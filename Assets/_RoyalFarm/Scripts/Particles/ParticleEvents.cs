using System;
using _RoyalFarm.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace _RoyalFarm.Scripts.Particles
{
    public class ParticleEvents : MonoSingleton<ParticleEvents>
    {
        public Func<ParticleType, GameObject> onCreateParticleGameObject = delegate { return null; };
        
        public UnityAction<Vector3[]> onSeedsCollidedPositions = delegate { };
    }
}