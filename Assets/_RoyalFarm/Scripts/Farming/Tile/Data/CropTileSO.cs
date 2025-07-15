using UnityEngine;

namespace _RoyalFarm.Scripts.Crop
{
    [CreateAssetMenu(fileName = "CropTileSO", menuName = "Royal Farm/CropTileSO", order = 0)]
    public class CropTileSO : ScriptableObject
    {
        public CropTileData Data;
    }
}