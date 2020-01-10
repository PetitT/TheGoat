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
    }

    private void Start()
    {
        GoatCollisionManager.instance.onDamageTaken += DamageTakenHandler;        
    }

    private void DamageTakenHandler()
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        health--;
        ParticlesManager.instance.PlaySmallBlood();
        SoundManager.instance.PlaySound(SoundManager.Sound.splat);

        if (health <= 0)
        {
            onDeath?.Invoke();
        }
    }
}
