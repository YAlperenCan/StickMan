using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed = 3f;
    public float jumpForce = 40f;

    private float inputX;
    private bool isMoving = false;
    private bool isGrounded = false;

    public Transform groundCheck; 
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    void Update()
    {

        inputX = Input.GetAxisRaw("Horizontal");

        if (inputX != 0)
        {
            isMoving = true;
            anim.Play(inputX > 0 ? "WalkRight" : "WalkLeft");
        }
        else
        {
            isMoving = false;
            anim.Play("idle");
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputX * moveSpeed, rb.linearVelocity.y);

        // Yere basýyor mu kontrolü
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
   
}
