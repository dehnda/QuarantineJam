using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JunkMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite = null;
    [SerializeField]
    private float floatSpeed = 2f;
    private bool Floating = false;
    private Rigidbody2D rb = null;
    private SpriteRenderer bubble = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetJunkFloating()
    {
        SetBubble();
        rb.gravityScale = -floatSpeed;
        Floating = true;
    }

    void SetBubble()
    {
        bubble = gameObject.GetComponent<SpriteRenderer>();
        bubble.sprite = sprite;
    }
}
