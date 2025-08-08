using System;
using _RoyalFarm.Scripts.Utilities;
using UnityEngine;

namespace _RoyalBase.Scripts.Particles
{
    public class ParticleEvents : MonoSingleton<ParticleEvents>
    {
        public Func<ParticleType, GameObject> onCreateParticleGameObject = delegate { return null; };
    }
}