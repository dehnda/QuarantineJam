using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BubbleNator : MonoBehaviour
{
    private CircleCollider2D circle = null;
    // Start is called before the first frame update
    private JunkMovement target = null;
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && (target != null))
        {
            target.SetJunkFloating();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Junk"))
        {
            target = other.GetComponent<JunkMovement>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Junk"))
        {
            target = null;
        }
    }
}
