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
        
        private CropTileStates _state;
        
        private void Start()
        {
            _state = CropTileStates.Empty;
            _crop = null;
        }

        internal void Initialize(CropField cropField)
        {
            _cropField = cropField;

            _cropPrefab = Resources.Load<GameObject>("Prefabs/Crop");
            _cropData = Resources.Load<CropSO>($"Data/CropSO{_cropField.GetType().ToString()}").Data;
        }
        
        public bool IsEmpty()
        {
            return _state == CropTileStates.Empty;
        }
        
        public void Seed()
        {
            if (!IsEmpty()) return;
            
            Debug.Log("Seed this tile: " + gameObject.name);
            
            _state = CropTileStates.Seeded;

            //TODO crop pool, factory init etmeli
            var cropGameObject = Instantiate(_cropPrefab, cropParent);
            _crop = cropGameObject.GetComponent<Crop>();
            if (_crop != null) _crop.Initialize(_cropData);
        }
    }
}