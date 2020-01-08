using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatAttack : MonoBehaviour
{
    public static GoatAttack instance;

    public event Action<bool> onAttack;

    public List<GameObject> attackObjects;
    public float attackCooldown;
    public float attackTime;

    private bool canAttack = true;
    [HideInInspector] public float remainingAttackCooldown { get; private set; }

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        CheckAttack();
        AttackCountDown();
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
        onAttack?.Invoke(true);
        foreach (var item in attackObjects)
        {
            item.SetActive(true);
        }
        remainingAttackCooldown = attackCooldown;
        canAttack = false;
        yield return new WaitForSeconds(attackTime);
        onAttack?.Invoke(false);
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
