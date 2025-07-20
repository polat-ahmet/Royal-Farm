using System;
using System.Collections;
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

        public CropFieldStateType State { get; private set; }
        private HashSet<CropTile> _processedTiles;
        
        private void Awake()
        {
            
        }
        
        // internal CropType GetType() => cropFieldSO.Data.Type;

        private void Start()
        {
            State = CropFieldStateType.Empty;
            
            _processedTiles = new HashSet<CropTile>();
            
            foreach (CropTile tile in cropTiles)
            {
                tile.Initialize(this, cropFieldSO.Crop.Data);
            }
        }

        internal void TileSeeded(CropTile tile)
        {
            if (_processedTiles.Add(tile) && _processedTiles.Count >= cropTiles.Count)
            {
                State = CropFieldStateType.Seeded;
                Debug.Log("Cropfieldf seeded");

                StartCoroutine(StartGrowingCoroutine());
                
                
                FarmingEvents.Instance.onCropFieldStateChanged?.Invoke(this, State);
            }
        }

        IEnumerator StartGrowingCoroutine()
        {
            foreach (CropTile tile in cropTiles)
            {
                tile.StartGrowing();
            }
            
            yield return new WaitForSeconds(cropFieldSO.Crop.Data.GrowingTime);
            
            Debug.Log("Cropfield growing finished");
        }
    }
}