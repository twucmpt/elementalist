using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }
}
