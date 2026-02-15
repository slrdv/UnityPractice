using UnityEngine;

namespace Game
{
    public sealed class PlayerAimSystem : IUnitAimSystem
    {
        private readonly IInputProvider _inputProvider;

        public PlayerAimSystem(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public Vector3 CalculateFaceDirection(Vector3 position)
        {
            Vector2 targetVector = _inputProvider.GetAimInput();
            return new Vector3(targetVector.x, 0, targetVector.y).normalized;
        }
    }
}
