using UnityEngine;

namespace Game
{
    public sealed class EnemyMovementSystem : IUnitMovementSystem
    {
        private readonly ILevelBoundsService _boundsService;

        public EnemyMovementSystem(ILevelBoundsService boundsService)
        {
            _boundsService = boundsService;
        }

        public Vector3 CalculateMovement(float deltaTime, Vector3 position, Vector3 direction, float speed)
        {
            Vector3 velocity = direction * speed * deltaTime;

            Vector3 nextPosition = position + velocity;
            if (_boundsService.IsOutOfBounds(nextPosition))
            {
                velocity = _boundsService.GetReflection(nextPosition, velocity);
            }

            return velocity;
        }
    }
}
