using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public event Action onDeath;

    public int health;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

        GoatCollisionManager.instance.onDamageTaken += DamageTakenHandler;
    }

    private void DamageTakenHandler()
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            onDeath?.Invoke();
        }
    }
}
