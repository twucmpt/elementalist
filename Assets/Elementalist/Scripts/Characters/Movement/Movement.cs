using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    protected Vector2 moveVal;
    private Rigidbody2D rb;

    public virtual float GetMoveSpeed() {
        return moveSpeed;
    }

    public virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    public Animator animator;

    protected virtual void FixedUpdate() {
        if ((transform.localScale.x > 0 && moveVal.x > 0) || (transform.localScale.x < 0 && moveVal.x < 0)) {
            transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
        rb.velocity = new Vector3(moveVal.x, moveVal.y, 0) * GetMoveSpeed() * Time.fixedDeltaTime;
        
        if(animator != null) {
            animator.SetBool("IsMoving", moveVal != Vector2.zero);
        }
    }
}
