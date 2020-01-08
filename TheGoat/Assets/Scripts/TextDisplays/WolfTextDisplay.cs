using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTextDisplay : BasicTextDisplay
{
    public string GameOverText;

    private void Start()
    {
        TimelineListener.instance.onWolfTalk += DisplayTextHandler;
        TimelineListener.instance.onWolfLastWords += DeathHandler;
    }

    private void DeathHandler()
    {
        DisplaySpecificText(GameOverText);
    }
}
