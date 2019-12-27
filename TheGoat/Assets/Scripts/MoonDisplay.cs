using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonDisplay : MonoBehaviour
{
    public Animator moonAnim;

    private float gameTime;

    private void Start()
    {
        gameTime = GameTime.instance.gameTime;
    }

    private void Update()
    {
        DisplayMoon();
    }

    private void DisplayMoon()
    {
        float percent = 1 - GameTime.instance.remainingGameTime / gameTime;

        moonAnim.SetFloat("Percentage", percent);
    }
}
