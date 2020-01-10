using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFlurry : BaseAttack
{
    public GameObject body;
    public Transform wolfSpinPos;
    public Transform wolfLandPos;
    public float securityDistance;
    public float jumpSpeed;
    public float attackDuration;
    public float attackFrequency;
    public GameObject claw;
    public float clawSpeed;
    public float clawRotationSpeed;
    public float clawLifeTime;

    private float remainingDuration;
    private float remainingFrequency;

    public override void Attack()
    {
        StartCoroutine(GetInPosition());
    }

    private void Start()
    {
        remainingDuration = attackDuration;
        remainingFrequency = attackFrequency;
    }

    private IEnumerator GetInPosition()
    {
        WolfAnimManager.instance.Jump();
        SoundManager.instance.PlaySound(SoundManager.Sound.wolfHowl);
        while (!CheckDistance(wolfSpinPos))
        {
            transform.position = Vector2.Lerp(transform.position, wolfSpinPos.position, jumpSpeed);
            yield return null;
        }
        StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        WolfAnimManager.instance.Spin();
        while(remainingDuration > 0)
        {
            remainingFrequency -= Time.deltaTime;
            if(remainingFrequency <= 0)
            {
                LaunchProjectile();
                remainingFrequency = attackFrequency;
            }
            remainingDuration -= Time.deltaTime;
            yield return null;
        }
        WolfAnimManager.instance.StopSpin();
        remainingDuration = attackDuration;
        remainingFrequency = attackFrequency;
        StartCoroutine(Land());
    }

    private IEnumerator Land()
    {
        while (!CheckDistance(wolfLandPos))
        {
            transform.position = Vector2.Lerp(transform.position, wolfLandPos.position, jumpSpeed);
            yield return null;
        }
        WolfAnimManager.instance.Land();
        AttackFinished();
    }

    private void LaunchProjectile()
    {
        GameObject newClaw = Pool.instance.GetItemFromPool(claw, transform.position);
        newClaw.GetComponent<LaunchedToothBehaviour>().Initialize(clawLifeTime, clawSpeed, clawRotationSpeed, body.transform.right);
    }

    private bool CheckDistance(Transform destination)
    {
        float distance = Vector2.Distance(transform.position, destination.position);
        if(distance > securityDistance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
