using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatMenu : MonoBehaviour
{
    public Transform left, right;
    private bool movingRight = true;
    public SpriteRenderer sprite;
    public float moveSpeed;
    public GameObject body;
    public float currentMoveSpeed;
    private bool isJumping = false;
    private float YMove;
    public float baseJumpForce;
    public float gravity;
    public float distanceFromGround;
    public LayerMask ground;

    private void Update()
    {
        ClampPos();
        Move();
        Jump();
        ApplyGravity();
        CheckGround();
    }

    private void CheckGround()
    {
        if (isJumping)
        {
            if (Physics2D.OverlapCircle(transform.position, distanceFromGround, ground))
            {
                isJumping = false;
            }
        }
    }

    private void ApplyGravity()
    {
        if (isJumping)
        {
            YMove -= gravity * Time.deltaTime;
            gameObject.transform.Translate(Vector2.up * YMove * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                YMove = baseJumpForce;
                isJumping = true;              
            }
        }
    }

    private void Move()
    {
        float X = Input.GetAxis("Horizontal");

        if (X > 0)
        {
            sprite.flipX = false;
        }
        else if (X < 0)
        {
            sprite.flipX = true;
        }

        gameObject.transform.Translate(Vector2.right * X * currentMoveSpeed * Time.deltaTime);

    }


    private void ClampPos()
    {
        if (transform.position.x >= right.position.x)
        {
            movingRight = false;
            sprite.flipX = true;
        }
        if (transform.position.x <= left.position.x)
        {
            movingRight = true;
            sprite.flipX = false;
        }
    }
}
