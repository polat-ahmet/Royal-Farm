using UnityEngine;

namespace _RoyalFarm.Scripts.Crop
{
    public class CropTile : MonoBehaviour, ISeedable
    {
        
        
        public void Seed()
        {
            Debug.Log("Seed this tile: " + gameObject.name);
        }
    }
}