using System;
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

    [Header("Animation")]
    public Animator anim;
    public GameObject body;

    [Header("Attack")]
    public List<GameObject> attackObjects;
    public float attackCooldown;
    public float buffedMoveSpeed;
    public float attackTime;

    private float currentMoveSpeed;
    private float YMove;
    private bool isJumping = true;
    private bool canAttack = true;
    private float remainingAttackCooldown;

    private void Start()
    {
        currentMoveSpeed = baseMoveSpeed;
    }

    void Update()
    {
        Move();
        Jump();
        ApplyGravity();
        CheckGround();
        CheckAttack();
        AttackCountDown();
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
            }
        }
    }

    private void CheckAttack()
    {
        if (canAttack)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine("Attack");
            }
        }
    }

    private IEnumerator Attack()
    {
        foreach (var item in attackObjects)
        {
            item.SetActive(true);
        }
        currentMoveSpeed = buffedMoveSpeed;
        remainingAttackCooldown = attackCooldown;
        canAttack = false;
        yield return new WaitForSeconds(attackTime);
        currentMoveSpeed = baseMoveSpeed;
        foreach (var item in attackObjects)
        {
            item.SetActive(false);
        }
    }

    private void AttackCountDown()
    {
        if (!canAttack)
        {
            remainingAttackCooldown -= Time.deltaTime;
            if (remainingAttackCooldown <= 0)
            {
                canAttack = true;
            }
        }
    }
}
