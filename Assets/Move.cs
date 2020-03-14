using Unity;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Move : MonoBehaviour
{
    [SerializeField]
    private bool jump = false;
    [SerializeField]
    private float jumpForce = 400f;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private Vector2 velocity;
    private Rigidbody2D rb2D;

    private bool LookRight = true;

    private Animator animator = null;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");

        velocity = new Vector2(h, 0f);

        velocity *= speed;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump = true;
            Debug.Log("Jump");
        }

        animator.SetFloat("speed", Mathf.Abs(h));

        animator.SetBool("isJumping", !IsGrounded());

        // just flip if not already and moving
        if ((h > 0f) && !LookRight)
        {
            FlipPlayer();
        }
        else if ((h < 0f) && LookRight)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        LookRight = !LookRight;

        // by multiply x * (-1) we just flip the char
        var localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    bool IsGrounded()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        return rb2D.IsTouchingLayers(layerMask);

    }

    void FixedUpdate()
    {

        if (jump)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            jump = false;
        }

        rb2D.velocity = new Vector2(velocity.x, rb2D.velocity.y);
    }
}