using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCompletedMessage : MonoBehaviour
{
public SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
}
