using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatCollisionManager : MonoBehaviour
{
    public static GoatCollisionManager instance;

    private bool isShielded = false;
    private bool isDamageable = true;
    private bool isInvulnerable = true;
    public float invulnerabilityTimer;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        GoatAttack.instance.onAttack += OnAttackHandler;
        TimelineListener.instance.onControlShift += ControlShiftHandler;
    }

    private void ControlShiftHandler(bool obj)
    {
        isInvulnerable = !obj;
    }

    private void OnAttackHandler(bool isAttacking)
    {
        isShielded = isAttacking;
    }

    public event Action onDamageTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DamageDealer"))
        {
            if (!isShielded && isDamageable && !isInvulnerable)
            {
                onDamageTaken?.Invoke();
                StartCoroutine(InvulnerabilityTime());
                SoundManager.instance.PlaySound(SoundManager.Sound.goatDamage);
            }
            else if(isShielded)
            {
                ParticlesManager.instance.PlayBlock();
            }
        }
    }

    private IEnumerator InvulnerabilityTime()
    {
        isDamageable = false;
        yield return new WaitForSeconds(invulnerabilityTimer);
        isDamageable = true;
    }
}
