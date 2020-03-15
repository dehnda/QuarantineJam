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
        var leftPos = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f));
        if (Floating && (transform.position.y > leftPos.y))
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
        if (itemType == ItemType.Fruit)
        {
            SoundManagerScript.PlaySound(Sounds.BADCATCH);
        }
        else
        {
            SoundManagerScript.PlaySound(Sounds.GOODCATCH);
        }

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
