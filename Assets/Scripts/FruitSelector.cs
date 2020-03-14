using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FruitSelector : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = new Sprite[9];
    private SpriteRenderer spriteRenderer = null;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, 9)];
    }
}
