using UnityEngine;

namespace Game
{
    public sealed class EnemyAimSystem : IUnitAimSystem
    {
        private readonly IUnitRegistry _unitRegistry;

        private Transform _target;

        public EnemyAimSystem(IUnitRegistry unitRegistry)
        {
            _unitRegistry = unitRegistry;

            _unitRegistry.PlayerRegisteredEvent += OnPlayerRegistered;
            _unitRegistry.PlayerUnregisteredEvent += OnPlayerUnregistered;
        }

        public Vector3 CalculateRotation(Vector3 position)
        {
            if (_target == null) return Vector3.zero;

            Vector3 targetVector = _target.position - position;
            targetVector.y = 0f;
            return targetVector.normalized;
        }

        public void Dispose()
        {
            _unitRegistry.PlayerRegisteredEvent -= OnPlayerRegistered;
            _unitRegistry.PlayerUnregisteredEvent -= OnPlayerUnregistered;
        }

        private void OnPlayerRegistered(UnitController target)
        {
            _target = target.View.transform;
        }

        private void OnPlayerUnregistered()
        {
            _target = null;
        }

    }
}
