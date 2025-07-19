using _RoyalFarm.Scripts.Commands;
using _RoyalFarm.Scripts.Crop;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player.Commands
{
    public class SeedAction : IGameplayAction
    {
        private readonly Vector3 _origin;
        private readonly Vector3 _direction;
        private readonly float _angle;     // in degrees
        private readonly float _radius;
        private readonly LayerMask _seedableMask;
        private readonly bool _visualize;

        public SeedAction(Vector3 origin, Vector3 direction, float angle, float radius, LayerMask seedableMask, bool visualize = false)
        {
            this._origin = origin;
            this._direction = direction.normalized;
            this._angle = angle;
            this._radius = radius;
            this._seedableMask = seedableMask;
            this._visualize = visualize;
        }

        public void Execute()
        {
            Collider[] hits = Physics.OverlapSphere(_origin, _radius, _seedableMask);
            
            foreach (var hit in hits)
            {
                Vector3 toTarget = hit.transform.position - _origin;
                float distance = toTarget.magnitude;
                
                float angleToTarget = Vector3.Angle(_direction, toTarget);
                
                if (distance <= _radius && angleToTarget <= _angle / 2f)
                {
                    if (hit.TryGetComponent<ISeedable>(out var seedable))
                    {
                        seedable.Seed();
                    }

                    if (_visualize)
                    {
                        Debug.DrawLine(_origin, hit.transform.position, Color.green, 2f);
                    }
                }
            }

            if (_visualize)
            {
                DrawConeDebug();
            }
        }

        private void DrawConeDebug()
        {
            int segments = 20;
            float halfAngle = _angle * 0.5f;

            for (int i = 0; i <= segments; i++)
            {
                float horizAngle = -halfAngle + (_angle / segments) * i;

                for (int j = 0; j <= segments; j++)
                {
                    float vertAngle = -halfAngle + (_angle / segments) * j;

                    Quaternion rot = Quaternion.Euler(vertAngle, horizAngle, 0);
                    Vector3 dir = rot * _direction;
                    Debug.DrawRay(_origin, dir.normalized * _radius, Color.red, 2f);
                }
            }
        }
    }
}