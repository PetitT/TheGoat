using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public float gameTime;

    public event Action onGameFinished;

    [HideInInspector] public float remainingGameTime;
    public static GameTime instance;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

        remainingGameTime = gameTime;
    }

    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        remainingGameTime -= Time.deltaTime;
        if(remainingGameTime <= 0)
        {
            onGameFinished?.Invoke();
        }
    }
}
