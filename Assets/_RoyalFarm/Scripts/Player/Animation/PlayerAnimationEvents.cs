using UnityEngine;

namespace _RoyalFarm.Scripts.Player.Animation
{
    public class PlayerAnimationEvents : MonoBehaviour
    {
        private void OnSeedingAnimationEvent()
        {
            PlayerEvents.Instance.onSeedingAnimationEventTriggered?.Invoke();
        }
    }
}