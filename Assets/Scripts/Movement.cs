using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    protected Vector2 moveVal;
    public Animator animator;

    protected virtual void FixedUpdate() {
        if ((transform.localScale.x < 0 && moveVal.x > 0) || (transform.localScale.x > 0 && moveVal.x < 0)) {
            transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
        transform.Translate(new Vector3(moveVal.x, moveVal.y, 0) * moveSpeed * Time.fixedDeltaTime);
        
        if(animator != null) {
            animator.SetBool("IsMoving", moveVal != Vector2.zero);
        }
    }
}
