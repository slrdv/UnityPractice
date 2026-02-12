using System;
using UnityEngine;

namespace Game
{
    public sealed class EnemyMovementSystem : IUnitMovementSystem
    {
        public event Action<Vector3> MoveEvent;

        public void SetSpeed(float speed)
        {

        }
        public void Tick(float delta)
        {

        }
    }
}
