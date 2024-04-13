using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveVal;

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void FixedUpdate() {
        if ((transform.localScale.x < 0 && moveVal.x > 0) || (transform.localScale.x > 0 && moveVal.x < 0)) {
            transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
        transform.Translate(new Vector3(moveVal.x, moveVal.y, 0) * moveSpeed * Time.fixedDeltaTime);
    }
}
