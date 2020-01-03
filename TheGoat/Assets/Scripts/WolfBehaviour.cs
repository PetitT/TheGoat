using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    public List<BaseAttack> attacks;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            attacks[0].Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            attacks[1].Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            attacks[2].Attack();
        }
    }
}
