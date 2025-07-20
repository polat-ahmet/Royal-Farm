using _RoyalFarm.Scripts.Crop.Data;
using JetBrains.Annotations;
using UnityEngine;

namespace _RoyalFarm.Scripts.Crop
{
    public class CropTile : MonoBehaviour, ISeedable
    {
        [SerializeField] private Transform cropParent;
        [SerializeField] private MeshRenderer tileRenderer;
        
        private GameObject _cropPrefab;
        
        [CanBeNull] private Crop _crop;
        private CropField _cropField;
        
        // private CropTileData _data;
        private CropData _cropData;
        
        private CropTileStateType _stateType;
        
        private void Start()
        {
            _stateType = CropTileStateType.Empty;
            _crop = null;
        }

        internal void Initialize(CropField cropField, CropData cropData)
        {
            _cropField = cropField;
            _cropData = cropData;

            _cropPrefab = Resources.Load<GameObject>("Prefabs/Crop");
            // _cropData = Resources.Load<CropSO>($"Data/CropSO{_cropField.GetType().ToString()}").Data;
        }
        
        public bool IsEmpty()
        {
            return _stateType == CropTileStateType.Empty;
        }
        
        //TODO execute, state durumuna göre
        public void Seed()
        {
            if (!IsEmpty()) return;
            
            Debug.Log("Seed this tile: " + gameObject.name);
            _stateType = CropTileStateType.Seeded;

            //TODO crop pool, factory init etmeli
            CreateCrop();
            
            _cropField.TileSeeded(this);
        }

        private void CreateCrop()
        {
            var cropGameObject = Instantiate(_cropPrefab, cropParent);
            
            if (cropGameObject.TryGetComponent<Crop>(out var crop))
            {
                _crop = crop;
                _crop.Initialize(_cropData);
            }
            
            // _crop = cropGameObject.GetComponent<Crop>();
            // if (_crop != null) _crop.Initialize(_cropData);
        }

        internal void UpdateCropProgress(float progress)
        {
            if (_crop == null) return;
            
            _crop.UpdateProgress(progress);
        }

        public void StartGrowing()
        {
            if (_crop == null) return;
            
            _crop.StartGrowing();
        }
    }
}