using UnityEngine;

namespace Game
{
    public sealed class KeyboardInputProvider : IInputProvider
    {
        public bool GetAttackInput()
        {
            return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        }

        public Vector2 GetCursorPosition()
        {
            return Input.mousePosition;
        }

        public Vector2 GetMovementInput()
        {
            Vector2 input = Vector2.zero;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) input.x = -1;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) input.x = 1;
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) input.y = 1;
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) input.y = -1;

            return input;
        }
    }
}

