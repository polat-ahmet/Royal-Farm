using System;
using _RoyalFarm.Scripts.Farming;
using UnityEngine;

namespace _RoyalFarm.Scripts.Crop.Data
{
    [Serializable]
    public struct CropData
    {
        public string Name;
        public CropType Type;
        
        public ModelLevel[] Models;
        public float GrowingTime;
        
        public Sprite CropIcon;
        public int Price;
    }
    
    [Serializable]
    public struct ModelLevel
    {
        public GameObject ModelPrefab;
        public float StartProgressPercentage;
    }
}