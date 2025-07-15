using _RoyalFarm.Scripts.Crop;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player
{
    public class PlayerDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //TODO try get component abstract interface
            if (other.CompareTag("CropField"))
            {
                var cropField = other.gameObject.GetComponent<CropField>();
                PlayerEvents.Instance.onCropFieldEntered?.Invoke(cropField);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("CropField"))
            {
                var cropField = other.gameObject.GetComponent<CropField>();
                PlayerEvents.Instance.onCropFieldExited?.Invoke(cropField);
            }
        }
    }
}