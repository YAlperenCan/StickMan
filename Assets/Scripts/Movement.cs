using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed = 3f;
    public float jumpForce = 12f;

    private float inputX;
    private bool isMoving = false;
    private bool isGrounded = false;

    public Transform groundCheck; // yere temas noktasýný kontrol eder
    public float groundCheckRadius = 0.9f;
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

        // Zýplama giriþ kontrolü
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
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
