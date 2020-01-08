using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatDamagedAnim : DamagedAnim
{
    private void Start()
    {
        GoatCollisionManager.instance.onDamageTaken += DamagedHandler;
    }
}
