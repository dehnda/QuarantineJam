using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BubbleNator : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle = null;
    private CircleCollider2D circle = null;
    // Start is called before the first frame update
    private MovementItems target = null;

    void Awake()
    {
        particle = particle.GetComponent<ParticleSystem>();
        particle.Stop();

    }
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            SoundManagerScript.PlaySound(Sounds.SHOOT);
            FireBubbleParticles();
            if (target != null)
            {

                target.SetFloatingTarget();
                target = null;
            }
        }

        if (Input.GetButton("Fire2") && (target != null))
        {
            target.SetEatingTarget();
            target = null;
        }
    }

    private void FireBubbleParticles()
    {
        particle.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Junk") || other.CompareTag("Fruit"))
        {
            target = other.GetComponent<MovementItems>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Junk") || other.CompareTag("Fruit"))
        {
            target = null;
        }
    }
}
