using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatCollisionManager : MonoBehaviour
{
    public static GoatCollisionManager instance;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public event Action onDamageTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DamageDealer"))
        {
            onDamageTaken?.Invoke();
        }
    }
}
