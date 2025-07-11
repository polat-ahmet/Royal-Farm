using System;
using UnityEngine;

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
        public Vector3 MoveVector; 
    }
}