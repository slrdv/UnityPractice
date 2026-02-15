using UnityEngine;

namespace Game
{
    public sealed class PlayerMovementSystem : IUnitMovementSystem
    {
        private readonly IInputProvider _inputProvider;
        private readonly ILevelBoundsService _boundsService;

        private float _speed;

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public PlayerMovementSystem(IInputProvider inputProvider, ILevelBoundsService boundsService)
        {
            _inputProvider = inputProvider;
            _boundsService = boundsService;
        }

        public Vector3 CalculateMovement(float delta, Vector3 position, Vector3 direction)
        {
            Vector2 inputVector = _inputProvider.GetMovementInput().normalized;
            Vector3 velocity = new Vector3(inputVector.x, 0, inputVector.y) * _speed * delta;

            if (_boundsService.IsOutOfBounds(position + velocity))
            {
                velocity = _boundsService.GetReflection(position + velocity, velocity);
            }

            return velocity;
        }
    }
}
