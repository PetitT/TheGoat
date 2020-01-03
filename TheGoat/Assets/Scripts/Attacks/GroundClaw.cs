using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundClaw : BaseAttack
{
    public GameObject claw;
    public Transform groundPos;
    public float chargeTime;

    public override void Attack()
    {
        StartCoroutine("DoAttack");        
    }

    private IEnumerator DoAttack()
    {
        WolfAnimManager.instance.Attack();
        yield return new WaitForSeconds(chargeTime / 2);
        Vector2 pos = GetPos();
        yield return new WaitForSeconds(chargeTime / 2);
        Pool.instance.GetItemFromPool(claw, pos);
        yield return new WaitForSeconds(chargeTime);
        AttackFinished();
    }

    private Vector2 GetPos()
    {
        float X = GoatCollisionManager.instance.gameObject.transform.position.x;
        return new Vector2(X, groundPos.position.y);
    }
}
