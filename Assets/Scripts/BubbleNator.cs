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
    private List<MovementItems> targets = new List<MovementItems>();
    private bool isActive;

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
        if (!GameManager.GameIsRunning)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            SoundManagerScript.PlaySound(Sounds.SHOOT);
            FireBubbleParticles();

            foreach (var t in targets.ToArray())
            {
                t.SetFloatingTarget();
            }
        }
        else if (Input.GetButton("Fire2"))
        {
            foreach (var t in targets.ToArray())
            {
                t.SetEatingTarget();
            }
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
            targets.Add(other.GetComponent<MovementItems>());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Junk") || other.CompareTag("Fruit"))
        {
            targets.Remove(other.GetComponent<MovementItems>());
        }
    }
}
