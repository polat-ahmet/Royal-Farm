using UnityEngine;

namespace _RoyalFarm.Scripts.Crop.Data
{
    [CreateAssetMenu(fileName = "CropSO", menuName = "Royal Farm/CropSO", order = 0)]
    public class CropSO : ScriptableObject
    {
        public CropData Data;
    }
}