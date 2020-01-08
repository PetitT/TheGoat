using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownDisplay : NormalizedAnimDisplay
{
    protected override float GetCurrent()
    {
        return GoatAttack.instance.remainingAttackCooldown;
    }

    protected override float GetMaximum()
    {
        return GoatAttack.instance.attackCooldown;
    }
}
