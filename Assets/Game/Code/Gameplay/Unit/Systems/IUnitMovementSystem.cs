using System;
using UnityEngine;

namespace Game
{
    public interface IUnitMovementSystem
    {
        event Action<Vector3> MoveEvent;

        void SetSpeed(float speed);
        void Tick(float delta);
    }
}
