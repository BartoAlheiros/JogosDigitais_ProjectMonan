﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    private bool grounded;

    [SerializeField]
    private float walkSpeed;
    private Rigidbody2D rb;
    private Vector2 newMovement;

    private Vector3 position;

    private Quaternion rotation;

    private Transform transform;

    private bool facingRight = true;
    private bool jump;
    private bool doubleJump;
    private float jumpForce = 550;

    private PlayerAnimation playerAnimation;

    private PlayerInput playerInput;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInput = GetComponent<PlayerInput>();
        transform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (grounded)
            doubleJump = false;

        playerAnimation.SetOnGround(grounded);
        
    }

    private void FixedUpdate(){
        
        playerAnimation.SetOnAttack(false);
        
        rb.velocity = newMovement;
    
        if(playerInput.jumPressed){
            if(!doubleJump || grounded){
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);

                doubleJump = true;
            }
        }

        if(grounded && playerInput.attackPressed) {
            playerAnimation.SetOnAttack(true);
        }

        playerAnimation.SetVSpeed(rb.velocity.y);

    }

    public void Move(float direction){
        float currentSpeed = walkSpeed;
        newMovement = new Vector2(direction*currentSpeed, rb.velocity.y);

        playerAnimation.SetSpeed((int)Mathf.Abs(direction));

        if(facingRight && direction < 0){
            Flip();
        }
        else if(!facingRight && direction > 0){
            Flip();
        }
    }

    void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }

    public void setWalkSpeed(float speed)
    {
        walkSpeed = speed;
    }

}
