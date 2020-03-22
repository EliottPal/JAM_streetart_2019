﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CharacController : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public GameObject levelComplete;
    private levelCompletedMessage _completed;
    public Animator animator;
    public Rigidbody2D rigidbody2d;
    public BoxCollider2D boxCollider2d;
    public AudioSource jump;
    public AudioSource keySound;
    public AudioSource endSound;
    Vector3 originalPos;
    bool key;
    bool door;
    float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        originalPos = gameObject.transform.position;
        _completed = levelComplete.GetComponent<levelCompletedMessage>();
        _completed.sprite.enabled = false;
        key = false;
        door = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 position = transform.position;
        position.x = position.x + 2.8f * horizontal * Time.deltaTime;
        transform.position = position;

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z)))
        {
            jump.Play();
            jumpVelocity = 5f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        if (Input.GetKeyDown(KeyCode.R))
            gameObject.transform.position = originalPos;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        if (raycastHit2d.collider == null)
            return false;
        else
            return true;
    }

    public void ChangeKey()
    {
        key = true;
        keySound.Play();
        door = true;
    }

    public void ChangeEnd()
    {
        if (door == true) {
            endSound.Play();
            _completed.sprite.enabled = true;
        }
    }
}
