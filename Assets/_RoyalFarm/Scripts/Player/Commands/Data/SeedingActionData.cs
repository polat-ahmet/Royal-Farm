using System;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.Commands.Data
{
    [Serializable]
    public struct SeedingActionData
    {
        public float Angle;
        public float Radius;
        public LayerMask SeedableMask;
    }
}