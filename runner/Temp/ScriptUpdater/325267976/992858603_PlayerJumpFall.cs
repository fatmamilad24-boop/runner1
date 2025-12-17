using UnityEngine;

public class PlayerJumpFall : MonoBehaviour
{
    public float jumpForce = 6f;
    public float fallForce = 10f;

    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true; // start on ground
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
            isGrounded = false;
        }

        // Force Fall
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -fallForce, rb.linearVelocity.z);
            anim.SetBool("isFalling", true);
            anim.SetBool("isJumping", false);
        }

        // Auto detect falling
        if (rb.linearVelocity.y < -0.2f && !isGrounded)
        {
            anim.SetBool("isFalling", true);
            anim.SetBool("isJumping", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        // Trees
        if (collision.gameObject.CompareTag("Tree"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -fallForce, rb.linearVelocity.z);
            anim.SetBool("isFalling", true);
            anim.SetBool("isJumping", false);
        }
    }
}
