using UnityEngine;

namespace Game
{
    public sealed class LevelBoundsService : ILevelBoundsService
    {
        private readonly BoxCollider _collider;

        public LevelBoundsService(BoxCollider bounds)
        {
            _collider = bounds;
        }

        public Vector3 ClampPosition(Vector3 position)
        {
            Bounds b = _collider.bounds;
            return new Vector3(Mathf.Clamp(position.x, b.min.x, b.max.x), 0, Mathf.Clamp(position.z, b.min.z, b.max.z));
        }

        public bool IsOutOfBounds(Vector3 position)
        {
            return !_collider.bounds.Contains(position);
        }

        public Vector3 GetReflection(Vector3 position, Vector3 velocity)
        {
            Vector3 closestPoint = _collider.ClosestPoint(position);
            Vector3 normal = (position - closestPoint).normalized;
            Vector3 reflected = Vector3.Reflect(velocity.normalized, normal);
            reflected.y = 0f;

            return reflected.normalized * velocity.magnitude;
        }
    }
}
