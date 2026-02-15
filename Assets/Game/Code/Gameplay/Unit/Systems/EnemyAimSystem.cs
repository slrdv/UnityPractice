using UnityEngine;

namespace Game
{
    public sealed class EnemyAimSystem : IUnitAimSystem
    {
        private readonly IUnitRegistry _unitRegistry;

        public EnemyAimSystem(IUnitRegistry unitRegistry)
        {
            _unitRegistry = unitRegistry;
        }

        public Vector3 CalculateFaceDirection(Vector3 position)
        {
            Transform target = GetTarget();
            if (target == null) return Vector3.zero;

            Vector3 targetVector = target.position - position;
            targetVector.y = 0f;
            return targetVector.normalized;
        }

        private Transform GetTarget()
        {
            return _unitRegistry.Player?.View.transform;
        }
    }
}
