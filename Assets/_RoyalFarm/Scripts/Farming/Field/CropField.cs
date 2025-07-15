using System;
using System.Collections.Generic;
using _RoyalFarm.Scripts.Farming;
using _RoyalFarm.Scripts.Particles;
using UnityEngine;
using UnityEngine.Serialization;

namespace _RoyalFarm.Scripts.Crop
{
    public class CropField : MonoBehaviour
    {
        [SerializeField] private CropFieldSO cropFieldSO;
        [SerializeField] private List<CropTile> cropTiles = new List<CropTile>();
        
        private CropFieldStates _state;

        private void Awake()
        {
            
        }
        
        internal CropType GetType() => cropFieldSO.Data.Type;

        private void Start()
        {
            _state = CropFieldStates.Empty;
            
            foreach (CropTile tile in cropTiles)
            {
                tile.Initialize(this);
            }
        }
    }
}