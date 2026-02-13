using UnityEngine;

namespace Game
{
    public sealed class PlayerMovementSystem : IUnitMovementSystem
    {
        private readonly IInputProvider _inputProvider;

        public PlayerMovementSystem(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public Vector3 CalculateMovement(float delta, Vector3 position, Vector3 direction, float speed)
        {
            Vector2 inputVector = _inputProvider.GetMovementInput().normalized;

            return new Vector3(inputVector.x, 0, inputVector.y) * speed * delta;
        }
    }
}
