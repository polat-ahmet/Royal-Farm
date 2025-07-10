using System;

namespace _RoyalFarm.Scripts.Player.Data
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
    }

    [Serializable]
    public struct PlayerMovementData
    {
        public float Speed;
    }
}