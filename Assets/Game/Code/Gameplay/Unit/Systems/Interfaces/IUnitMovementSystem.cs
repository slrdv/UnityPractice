using UnityEngine;

namespace Game
{
    public interface IUnitMovementSystem
    {
        Vector3 CalculateMovement(float deltaTime, Vector3 position, Vector3 direction, float speed);
    }
}
