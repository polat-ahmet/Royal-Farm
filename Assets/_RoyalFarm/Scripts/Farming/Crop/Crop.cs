using System.Collections;
using _RoyalFarm.Scripts.Crop.Data;
using UnityEngine;

namespace _RoyalFarm.Scripts.Crop
{
    public class Crop : MonoBehaviour
    {
        [SerializeField] private Transform modelHolder;
        
        private CropData _data;

        private GameObject _modelGO;

        private ModelLevel[] _models;
        private int _currentLevelIndex;
        private float _progress;

        internal void Initialize(CropData data)
        {
            Debug.Log("Crop initialized");
            _data = data;
            _models = data.Models;

            _currentLevelIndex = 0;
            _progress = 0;
            
            //TODO pool
            _modelGO = Instantiate(_models[_currentLevelIndex].ModelPrefab, modelHolder);
        }

        internal void StartGrowing()
        {
            StartCoroutine(StartGrowingCoroutine());
        }
        
        IEnumerator StartGrowingCoroutine()
        {
            float progress = 0;
            
            float elapsedTime = 0;
            float endTime = _data.GrowingTime;
            
            Debug.Log($"Cropfield growing started total time: {endTime}");

            while (elapsedTime <= endTime)
            {
                yield return new WaitForSeconds(0.5f);
                
                elapsedTime += 0.5f;
                Debug.Log($"Elapsed time: {elapsedTime}");
                
                progress = elapsedTime / endTime;
                Debug.Log($"Crop growing progress: {progress:F2}");
                
                UpdateProgress(progress);
            }
            
            Debug.Log("Crop growing finished");

        }
        
        internal void UpdateProgress(float newProgress)
        {
            var newLevelIndex = FindModelIndexByProgress(newProgress);

            if (newLevelIndex == _currentLevelIndex) return;
            
            _currentLevelIndex = newLevelIndex;
            
            _modelGO.transform.SetParent(null);
            Destroy(_modelGO);
            
            _modelGO = Instantiate(_models[_currentLevelIndex].ModelPrefab, modelHolder);
        }

        private int FindModelIndexByProgress(float newProgress)
        {
            int newLevelIndex = 0;
            
            for (int tempIndex = 0; tempIndex < _models.Length; tempIndex++)
            {
                if (newProgress < _models[tempIndex].StartProgressPercentage) break;
                
                newLevelIndex = tempIndex;
            }

            return newLevelIndex;
        }
    }
}