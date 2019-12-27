using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatTextDisplay : BasicTextDisplay
{
    private void Start()
    {
        TimelineListener.instance.onGoatTalk += DisplayTextHandler;
    }
}
