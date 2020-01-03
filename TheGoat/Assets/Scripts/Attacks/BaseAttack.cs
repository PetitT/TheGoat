using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public event Action onAttackFinished;

    public virtual void Attack()
    {
        
    }

    protected void AttackFinished()
    {
        onAttackFinished?.Invoke();
    }
}
