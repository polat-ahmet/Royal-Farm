using System;
using UnityEngine;

namespace _RoyalBase.Scripts.Player.Data
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