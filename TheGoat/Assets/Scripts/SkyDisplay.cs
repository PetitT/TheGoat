using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyDisplay : NormalizedAnimDisplay
{
    protected override float GetCurrent()
    {
        return GameTime.instance.remainingGameTime;
    }

    protected override float GetMaximum()
    {
        return GameTime.instance.gameTime;
    }
}
