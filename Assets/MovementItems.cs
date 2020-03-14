using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Junk,
    Fruit
}

public class MovementItems : MonoBehaviour
{
    [SerializeField]
    private float points = 10f;
    [SerializeField]
    private Sprite sprite = null;
    [SerializeField]
    private float floatSpeed = 2f;
    [SerializeField]
    private ItemType itemType = ItemType.Fruit;
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
        if (Floating && (transform.position.y > 5f))
        {
            if (itemType == ItemType.Fruit)
            {
                FindObjectOfType<PointsController>().AddPoints(-points);
            }
            else if (itemType == ItemType.Junk)
            {
                FindObjectOfType<PointsController>().AddPoints(points);
            }

            Destroy(this.gameObject);
        }
    }

    public void SetFloatingTarget()
    {
        SetBubble();
        rb.gravityScale = -floatSpeed;
        Floating = true;
    }

    public void SetEatingTarget()
    {
        if (itemType == ItemType.Fruit)
        {
            FindObjectOfType<PointsController>().AddPoints(points);
        }
        else if (itemType == ItemType.Junk)
        {
            FindObjectOfType<PointsController>().AddPoints(-points);
        }

        Destroy(this.gameObject);
    }

    void SetBubble()
    {
        bubble = gameObject.GetComponent<SpriteRenderer>();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        bubble.sprite = sprite;
    }
}
