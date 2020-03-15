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
    private GameObject bubblePrefab = null;
    [SerializeField]
    private float points = 10f;

    [SerializeField]
    private float floatSpeed = 2f;
    [SerializeField]
    private ItemType itemType = ItemType.Fruit;
    private bool Floating = false;
    private Rigidbody2D rb = null;


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
                SoundManagerScript.PlaySound(Sounds.BADCATCH);
            }
            else if (itemType == ItemType.Junk)
            {
                FindObjectOfType<PointsController>().AddPoints(points);
                SoundManagerScript.PlaySound(Sounds.GOODCATCH);
            }

            Destroy(this.gameObject);
        }
    }

    public void SetFloatingTarget()
    {
        rb.gravityScale = -floatSpeed;
        SetBubble();
        Floating = true;
    }

    public void SetEatingTarget()
    {
        if (itemType == ItemType.Fruit)
        {
            FindObjectOfType<PointsController>().AddPoints(points);
            SoundManagerScript.PlaySound(Sounds.GOODCATCH);
        }
        else if (itemType == ItemType.Junk)
        {
            FindObjectOfType<PointsController>().AddPoints(-points);
            SoundManagerScript.PlaySound(Sounds.BADCATCH);
        }

        Destroy(this.gameObject);
    }

    void SetBubble()
    {
        // Disable collider when floating up
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // a bubble as child on food for visuals
        var bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        bubble.transform.parent = transform;
    }
}
