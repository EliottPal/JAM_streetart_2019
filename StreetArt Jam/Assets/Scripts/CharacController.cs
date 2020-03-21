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
    public Animator animator;
    public Rigidbody2D rigidbody2d;
    public BoxCollider2D boxCollider2d;
    public AudioSource jump;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float jumpVelocity;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 position = transform.position;
        position.x = position.x + 2.8f * horizontal * Time.deltaTime;
        transform.position = position;

        if (!IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z)))
        {
            jump.Play();
            animator.SetBool("isJumping", true);
            jumpVelocity = 4f;
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
}
