using System;
using UnityEngine;

namespace _RoyalFarm.Scripts.Particles
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private Transform seedParticleHolder;
        
        private GameObject _seedParticlePrefab;

        private const string SeedParticlePath = "Prefabs/Particles/SeedParticles";

        private void Awake()
        {
            LoadPrefabs();
        }

        private void LoadPrefabs()
        {
            _seedParticlePrefab = Resources.Load<GameObject>(SeedParticlePath);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ParticleEvents.Instance.onCreateParticleGameObject += CreateParticleGameObjectCallback;
        }

        private GameObject CreateParticleGameObjectCallback(ParticleType type)
        {
            //TODO particle factory
            return type switch
            {
                ParticleType.Seeding => Instantiate(_seedParticlePrefab, seedParticleHolder),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            ParticleEvents.Instance.onCreateParticleGameObject -= CreateParticleGameObjectCallback;
        }
    }
}