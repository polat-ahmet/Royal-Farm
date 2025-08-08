using UnityEngine;

namespace _RoyalBase.Scripts.Particles
{
    public class ParticleManager : MonoBehaviour
    {
        private void Awake()
        {
            LoadPrefabs();
        }

        private void LoadPrefabs()
        {
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
            return null;
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