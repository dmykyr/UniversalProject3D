using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float horizontalSpeed = 2.0f;
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = -9.81f;

    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("JumpTrigger");
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);

        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);

        animator.SetBool("IsWalking", move.magnitude > 0);
    }

    private bool IsGrounded()
    {
        return Mathf.Abs(rb.velocity.y) < 0.1f;
    }
}
