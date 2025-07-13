using _RoyalFarm.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace _RoyalFarm.Scripts.Particles
{
    public class ParticleEvents : MonoSingleton<ParticleEvents>
    {
        public UnityAction<Vector3[]> onSeedsCollided;
    }
}