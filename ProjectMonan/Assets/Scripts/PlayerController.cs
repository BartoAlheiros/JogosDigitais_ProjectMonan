﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D body;

    private Animator animator;

    private SpriteRenderer sprite;

    public float runSpeed = 10;

    public CircleCollider2D foot;

    public LayerMask ground;

    public float jumpForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetForwardInput();
        GetJumpInput();
    }

    private void GetJumpInput()
    {
        if(Input.GetButtonDown("Jump") && foot.IsTouchingLayers(ground)) {
            body.AddForce(Vector2.up * jumpForce);
        }
        animator.SetBool("isOnGround", foot.IsTouchingLayers(ground));
    }

    private void GetForwardInput()
    {
      body.velocity = new Vector2(Input.GetAxis("Horizontal")*runSpeed, body.velocity.y);
      animator.SetFloat("xSpeed", Math.Abs(body.velocity.x));
      if(!sprite.flipX && body.velocity.x < 0) {
          sprite.flipX = true;
      } else if(sprite.flipX && body.velocity.x > 0) {
          sprite.flipX = false;
      }
     
    }
}
