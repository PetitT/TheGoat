using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTextDisplay : BasicTextDisplay
{
    private void Start()
    {
        TimelineListener.instance.onWolfTalk += DisplayTextHandler;
    }
}
