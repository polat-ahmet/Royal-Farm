using System;
using _RoyalFarm.Scripts.Farming;

namespace _RoyalFarm.Scripts.Crop
{
    [Serializable]
    public struct CropFieldData
    {
        public byte Width;
        public byte Length;
        
        public CropType Type;
    }
}