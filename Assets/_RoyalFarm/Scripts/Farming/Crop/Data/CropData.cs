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
        public GameObject ModelPrefab;
        public float GrowingTime;
        
        public Sprite CropIcon;
        public int Price;
    }
}