using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawCarpet : BaseAttack
{
    public GameObject slowGroundClaw;
    public List<Transform> clawPos;
    public float duration;

    public override void Attack()
    {
        SoundManager.instance.PlaySound(SoundManager.Sound.wolfHowl);
        WolfAnimManager.instance.Attack();
        int random = UnityEngine.Random.Range(0, clawPos.Count);

        for (int i = 0; i < clawPos.Count; i++)
        {
            if (i != random)
            {
                GameObject newClaw = Pool.instance.GetItemFromPool(slowGroundClaw, clawPos[i].position);
            }
        }
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(duration);
        AttackFinished();
    }
}
