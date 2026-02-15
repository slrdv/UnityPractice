using UnityEngine;

namespace Game
{
    public interface IInputProvider
    {
        bool GetFireButtonPressed();
        Vector3 GetAimInput();
        Vector2 GetMovementInput();
    }
}
