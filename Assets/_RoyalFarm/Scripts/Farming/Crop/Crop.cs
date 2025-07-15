using _RoyalFarm.Scripts.Crop.Data;
using UnityEngine;

namespace _RoyalFarm.Scripts.Crop
{
    public class Crop : MonoBehaviour
    {
        [SerializeField] private Transform modelHolder;

        private CropData _data;
        
        internal void Initialize(CropData data)
        {
            Debug.Log("Crop initialized");
            _data = data;
            var cropGameObject = Instantiate(_data.ModelPrefab, modelHolder);
        }
    }
}