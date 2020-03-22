using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2d;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CharacController controller = other.GetComponent<CharacController>();

        if (controller != null)
        {
            gameObject.SetActive(true);
        }
    }
}
