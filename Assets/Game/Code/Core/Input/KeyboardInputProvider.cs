using UnityEngine;

namespace Game
{
    public sealed class KeyboardInputProvider : IInputProvider
    {

        public bool GetAttackInput()
        {
            return GetAimInput() != Vector3.zero;
        }

        public Vector2 GetMovementInput()
        {
            Vector2 input = Vector2.zero;

            if (Input.GetKey(KeyCode.A)) input.x += -1;
            if (Input.GetKey(KeyCode.D)) input.x += 1;
            if (Input.GetKey(KeyCode.W)) input.y += 1;
            if (Input.GetKey(KeyCode.S)) input.y += -1;

            return input;
        }

        public Vector3 GetAimInput()
        {
            Vector2 input = Vector2.zero;

            if (Input.GetKey(KeyCode.LeftArrow)) input.x += -1;
            if (Input.GetKey(KeyCode.RightArrow)) input.x += 1;
            if (Input.GetKey(KeyCode.UpArrow)) input.y += 1;
            if (Input.GetKey(KeyCode.DownArrow)) input.y += -1;

            return input;
        }
    }
}

