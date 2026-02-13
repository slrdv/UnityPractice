using UnityEngine;

namespace Game
{
    public interface ILevelBoundsService
    {
        Vector3 ClampPosition(Vector3 position);
        bool IsOutOfBounds(Vector3 position);
        Vector3 GetReflection(Vector3 position, Vector3 velocity);
    }
}
