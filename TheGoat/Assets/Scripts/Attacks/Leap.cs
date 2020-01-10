using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap : BaseAttack
{
    public Transform jumpHeight;
    public Transform groundedHeight;
    public float securityDistance;
    public float jumpSpeed;
    public float fallSpeed;
    public float waitTime;
    public GameObject body;

    public override void Attack()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        SoundManager.instance.PlaySound(SoundManager.Sound.wolfHowl);
        WolfAnimManager.instance.Jump();
        WolfAnimManager.instance.Spin();
        while (transform.position.y < jumpHeight.position.y - securityDistance)
        {
            float YPos = Mathf.Lerp(transform.position.y, jumpHeight.position.y, jumpSpeed);
            gameObject.transform.position = new Vector2(transform.position.x, YPos);
            yield return null;
        }
        WolfAnimManager.instance.StopSpin();
        gameObject.transform.position = new Vector2(transform.position.x, jumpHeight.position.y);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime / 2);
        float newTarget = FindTarget();
        yield return new WaitForSeconds(waitTime / 2);
        StartCoroutine(Fall(newTarget));
    }

    private float FindTarget()
    {
        return GoatCollisionManager.instance.gameObject.transform.position.x;
    }

    private IEnumerator Fall(float targetX)
    {
        WolfColliderManager.instance.ToggleCollider(true);
        while (transform.position.y > groundedHeight.position.y + securityDistance)
        {
            float YPos = Mathf.Lerp(transform.position.y, groundedHeight.position.y, fallSpeed);
            float XPos = Mathf.Lerp(transform.position.x, targetX, fallSpeed);
            gameObject.transform.position = new Vector2(XPos, YPos);
            yield return null;
        }
        gameObject.transform.position = new Vector2(targetX, groundedHeight.position.y);
        WolfAnimManager.instance.Land();
        WolfColliderManager.instance.ToggleCollider(false);
        AttackFinished();
    }
}
