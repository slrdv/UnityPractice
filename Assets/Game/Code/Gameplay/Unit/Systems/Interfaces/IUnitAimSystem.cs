using UnityEngine;
namespace Game
{
    public interface IUnitAimSystem
    {
        Vector3 CalculateFaceDirection(Vector3 position);
    }
}
