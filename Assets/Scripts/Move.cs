using System;
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

    [SerializeField]
    private Vector2 rightBorder = Vector2.zero;
    [SerializeField]
    private Vector2 leftBorder = Vector2.zero;
    [SerializeField]
    private Vector2 PlayerWorldPos = Vector2.zero;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameManager.GameIsRunning)
            return;

        var h = Input.GetAxis("Horizontal");

        velocity = new Vector2(h, 0f);

        velocity *= speed;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            SoundManagerScript.PlaySound(Sounds.JUMP);
            jump = true;
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

        CheckBorders();
    }

    private void CheckBorders()
    {

        rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));
        leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        PlayerWorldPos = transform.position;

        if (PlayerWorldPos.x > rightBorder.x)
        {
            var newPos = PlayerWorldPos;
            newPos.x = leftBorder.x;
            transform.position = newPos;
        }
        else if (PlayerWorldPos.x < leftBorder.x)
        {
            var newPos = PlayerWorldPos;
            newPos.x = rightBorder.x;
            transform.position = newPos;
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