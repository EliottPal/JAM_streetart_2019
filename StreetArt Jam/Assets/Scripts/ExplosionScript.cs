using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.enabled = true;
    }
}
