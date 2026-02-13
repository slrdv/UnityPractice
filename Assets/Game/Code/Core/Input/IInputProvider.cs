using UnityEngine;

namespace Game
{
    public interface IInputProvider
    {
        bool GetAttackInput();
        Vector2 GetCursorPosition();
        Vector2 GetMovementInput();
    }
}
