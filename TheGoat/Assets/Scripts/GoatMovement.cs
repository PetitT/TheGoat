﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatMovement : MonoBehaviour
{
    [Header("Movement")]
    public float baseMoveSpeed;

    [Header("Jump")]
    public float jumpForce;
    public float gravity;
    public Transform groundCheck;
    public LayerMask ground;
    public float distanceFromGround;

    [Header("Attack")]
    public float buffedMoveSpeed;

    [Header("Animation")]
    public Animator anim;
    public GameObject body;

    private float currentMoveSpeed;
    private float YMove;
    private bool isJumping = true;

    private void Start()
    {
        GoatAttack.instance.onAttack += AttackHandler;

        currentMoveSpeed = baseMoveSpeed;
    }

    private void AttackHandler(bool isAttacking)
    {
        currentMoveSpeed = isAttacking ? buffedMoveSpeed : baseMoveSpeed;
    }

    void Update()
    {
        Move();
        Jump();
        ApplyGravity();
        CheckGround();
    }


    private void Move()
    {
        float X = Input.GetAxis("Horizontal");

        if (X == 0)
        {
            anim.SetBool("IsMoving", false);
        }
        else
        {
            if (X > 0)
            {
                body.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                body.transform.rotation = new Quaternion(0, 180, 0, 0);
            }

            gameObject.transform.Translate(Vector2.right * X * currentMoveSpeed * Time.deltaTime);
            anim.SetBool("IsMoving", true);
        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                YMove = jumpForce;
                isJumping = true;
                anim.SetTrigger("Jump");
                ParticlesManager.instance.PlayGrass();
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

    private void CheckGround()
    {
        if (isJumping)
        {
            if (Physics2D.OverlapCircle(transform.position, distanceFromGround, ground))
            {
                isJumping = false;
                anim.SetTrigger("Land");
                ParticlesManager.instance.PlayGrass();
            }
        }
    }
}
