// Move sprite bottom left to upper right.  It does not stop moving.
// The Rigidbody2D gives the position for the cube.

using UnityEngine;
using Unity;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector2 velocity;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        velocity = new Vector2(h, 0f);

        velocity *= speed;
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
}