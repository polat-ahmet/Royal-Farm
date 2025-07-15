using System;
using _RoyalFarm.Scripts.Farming;
using UnityEngine;

namespace _RoyalFarm.Scripts.Crop.Data
{
    [Serializable]
    public struct CropData
    {
        public CropType Type;
        public GameObject ModelPrefab;
        public Sprite cropIcon;
        public int price;
    }
}