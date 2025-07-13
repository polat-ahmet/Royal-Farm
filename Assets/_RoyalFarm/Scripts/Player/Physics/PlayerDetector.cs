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
                // EnteredCropField(currentCropField);
                PlayerEvents.Instance.onCropFieldEntered?.Invoke(cropField);
            }
        }

        // private void OnTriggerStay(Collider other)
        // {
        //     if (other.CompareTag("CropField"))
        //     {
        //         EnteredCropField(other.GetComponent<CropField>());
        //     }
        // }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("CropField"))
            {
                var cropField = other.gameObject.GetComponent<CropField>();
                // playerAnimator.StopSowAnimation();
                // currentCropField = null;
                PlayerEvents.Instance.onCropFieldExited?.Invoke(cropField);
            }
        }

        // private void EnteredCropField(CropField cropField)
        // {
        //     if (playerToolSelector.CanSow())
        //     {
        //         playerAnimator.PlaySowAnimation();
        //     }
        // }
    }
}