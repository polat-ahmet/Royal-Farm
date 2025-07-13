using UnityEngine;

namespace _RoyalFarm.Scripts.Player
{
    public class PlayerDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("CropField"))
            {
                // currentCropField = other.gameObject.GetComponent<CropField>();
                // EnteredCropField(currentCropField);
                PlayerEvents.Instance.onCropFieldEntered?.Invoke();
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
                // playerAnimator.StopSowAnimation();
                // currentCropField = null;
                PlayerEvents.Instance.onCropFieldExited?.Invoke();
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