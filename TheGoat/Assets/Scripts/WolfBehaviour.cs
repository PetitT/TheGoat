using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    public List<BaseAttack> attacks;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            attacks[0].Attack();
        }
    }
}
