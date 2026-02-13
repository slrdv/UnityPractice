using UnityEngine;

namespace Game
{
    public interface IInputProvider
    {
        bool GetAttackInput();
        Vector3 GetAimInput();
        Vector2 GetMovementInput();
    }
}
