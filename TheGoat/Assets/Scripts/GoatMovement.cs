using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatMovement : MonoBehaviour
{
    [Header("Movement")]
    public float baseMoveSpeed;
    public Transform maxX, minX, minY;

    [Header("Jump")]
    public float baseJumpForce;
    public float gravity;
    public Transform groundCheck;
    public LayerMask ground;
    public float distanceFromGround;

    [Header("JumpIncrease")]
    public float jumpIncTimer;
    public float jumpIncForce;
    private bool isIncreasingJump = false;

    [Header("Attack")]
    public float buffedMoveSpeed;

    [Header("Animation")]
    public Animator anim;
    public GameObject body;

    private float currentJumpIncTimer;
    private float currentMoveSpeed;
    private float YMove;
    private bool isJumping = true;

    private void Start()
    {
        GoatAttack.instance.onAttack += AttackHandler;

        currentMoveSpeed = baseMoveSpeed;
        currentJumpIncTimer = jumpIncTimer;
    }

    private void AttackHandler(bool isAttacking)
    {
        currentMoveSpeed = isAttacking ? buffedMoveSpeed : baseMoveSpeed;
    }

    void Update()
    {
        Move();
        Jump();
        IncreaseJump();
        CheckJumpButton();
        ApplyGravity();
        CheckGround();
        ClampPos();
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
                YMove = baseJumpForce;
                isJumping = true;
                anim.SetTrigger("Jump");
                isIncreasingJump = true;
                ParticlesManager.instance.PlayGrass();
                SoundManager.instance.PlaySound(SoundManager.Sound.jump);
            }
        }
    }

    private void IncreaseJump()
    {
        if (isIncreasingJump)
        {
            currentJumpIncTimer -= Time.deltaTime;
            YMove += jumpIncForce * Time.deltaTime;

            if (currentJumpIncTimer <= 0)
            {
                currentJumpIncTimer = jumpIncTimer;
                isIncreasingJump = false;
            }
        }
    }

    private void CheckJumpButton()
    {
        if (isIncreasingJump)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isIncreasingJump = false;
                currentJumpIncTimer = jumpIncTimer;
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
                SoundManager.instance.PlaySound(SoundManager.Sound.leaf);
                ParticlesManager.instance.PlayGrass();
            }
        }
    }

    private void ClampPos()
    {
        float X = transform.position.x;
        float Y = transform.position.y;

        if (X > maxX.position.x)
            X = maxX.position.x;
        if (X < minX.position.x)
            X = minX.position.x;

        if (Y < minY.position.y)
            Y = minY.position.y;

        transform.position = new Vector2(X, Y);
    }

    private void OnDisable()
    {
        anim.SetTrigger("Land");
        anim.SetBool("IsMoving", false);
    }
}
