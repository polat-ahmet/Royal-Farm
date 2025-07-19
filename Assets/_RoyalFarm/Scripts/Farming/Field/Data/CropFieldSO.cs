using _RoyalFarm.Scripts.Crop.Data;
using _RoyalFarm.Scripts.Farming;
using UnityEngine;

namespace _RoyalFarm.Scripts.Crop
{
    [CreateAssetMenu(fileName = "CropFieldSO", menuName = "Royal Farm/CropFieldSO", order = 0)]
    public class CropFieldSO : ScriptableObject
    {
        public CropFieldData Data;
        public CropSO Crop;
    }
}