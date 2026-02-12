using System;
using UnityEngine;

namespace Game
{
    public sealed class PlayerMovementSystem : IUnitMovementSystem
    {
        public event Action<Vector3> MoveEvent;

        private readonly IInputProvider _inputProvider;

        private float _speed;

        public PlayerMovementSystem(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void Tick(float delta) => throw new NotImplementedException();
    }
}
