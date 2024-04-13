using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    protected Vector2 moveVal;

    protected virtual void FixedUpdate() {
        if ((transform.localScale.x < 0 && moveVal.x > 0) || (transform.localScale.x > 0 && moveVal.x < 0)) {
            transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
        transform.Translate(new Vector3(moveVal.x, moveVal.y, 0) * moveSpeed * Time.fixedDeltaTime);
    }
}
