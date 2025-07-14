using UnityEngine;

namespace _RoyalFarm.Scripts.Player.Commands
{
    public class SeedGameplayAction : IGameplayAction
    {
        
        public SeedGameplayAction()
        {
            
        }
        
        public void Execute()
        {
            Debug.Log("SeedAbility Execute");
        }
    }
}