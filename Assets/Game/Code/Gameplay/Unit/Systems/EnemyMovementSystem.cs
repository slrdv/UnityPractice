using UnityEngine;

namespace Game
{
    public sealed class EnemyMovementSystem : IUnitMovementSystem
    {
        private readonly ILevelBoundsService _boundsService;

        private float _speed;

        public EnemyMovementSystem(ILevelBoundsService boundsService)
        {
            _boundsService = boundsService;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public Vector3 CalculateMovement(float deltaTime, Vector3 position, Vector3 direction)
        {
            Vector3 velocity = direction * _speed * deltaTime;

            Vector3 nextPosition = position + velocity;
            if (_boundsService.IsOutOfBounds(nextPosition))
            {
                velocity = _boundsService.GetReflection(nextPosition, velocity);
            }

            return velocity;
        }
    }
}
