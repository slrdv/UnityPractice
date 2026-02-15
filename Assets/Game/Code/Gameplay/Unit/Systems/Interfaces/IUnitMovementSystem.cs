using UnityEngine;

namespace Game
{
    public interface IUnitMovementSystem
    {
        void SetSpeed(float speed);
        Vector3 CalculateMovement(float deltaTime, Vector3 position, Vector3 direction);
    }
}
