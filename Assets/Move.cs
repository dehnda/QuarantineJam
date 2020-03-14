using Unity;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Move : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 400f;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private Vector2 velocity;
    private Rigidbody2D rb2D;
    private BoxCollider2D boxCollider = null;
    private float distToGround = 0f;
    bool jump = false;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        // get the distance to ground
        distToGround = boxCollider.bounds.extents.y;
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