using System;
using _RoyalFarm.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace _RoyalFarm.Scripts.Particles
{
    public class ParticleEvents : MonoSingleton<ParticleEvents>
    {
        // public UnityAction<ParticleSystem> onPlayParticleRequest;
        // public UnityAction<ParticleSystem> onStopParticleRequest;
        //     
        public Func<ParticleType, GameObject> onCreateParticleGameObject = delegate { return null; };
        
        public UnityAction<Vector3[]> onSeedsCollidedPositions = delegate { };
    }
}