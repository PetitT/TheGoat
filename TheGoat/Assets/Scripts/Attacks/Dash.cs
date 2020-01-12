using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BaseAttack
{
    public Transform dashLeftPos, dashRightPos;
    public float runSpeed;
    public float windupTime;

    public override void Attack()
    {
        StartCoroutine(DoAttack());
    }

    private IEnumerator DoAttack()
    {
        SoundManager.instance.PlaySound(SoundManager.Sound.wolfGrowl);
        WolfAnimManager.instance.ToggleParticle(true);
        WolfAnimManager.instance.Charge(true);
        yield return new WaitForSeconds(windupTime);
        Vector2 direction;
        Transform destination;
        GetDashParams(out direction, out destination);
        WolfAnimManager.instance.Charge(false);
        WolfAnimManager.instance.Move(true);
        WolfColliderManager.instance.ToggleCollider(true);
        while (!CheckDestination(destination))
        {
            gameObject.transform.Translate(direction * runSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
        WolfAnimManager.instance.Move(false);
        WolfAnimManager.instance.ToggleParticle(false);
        WolfColliderManager.instance.ToggleCollider(false);
        AttackFinished();
    }

    private bool CheckDestination(Transform destination)
    {
        if (destination == dashLeftPos)
        {
            if (transform.position.x > dashLeftPos.position.x)
                return false;
            else
                return true;
        }
        else
        {
            if (transform.position.x < dashRightPos.position.x)
                return false;
            else
                return true;
        }
    }

    private void GetDashParams(out Vector2 direction, out Transform destination)
    {
        direction = LookAtGoat.instance.lookingLeft ? Vector2.left : Vector2.right;
        destination = LookAtGoat.instance.lookingLeft ? dashLeftPos : dashRightPos;
    }
}
