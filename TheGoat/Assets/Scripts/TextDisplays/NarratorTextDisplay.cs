using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorTextDisplay : BasicTextDisplay
{
    private void Start()
    {
        TimelineListener.instance.onNarratorTalk += DisplayTextHandler;

        tmp.sortingLayerID = GetComponent<SpriteRenderer>().sortingLayerID;
        tmp.sortingOrder = 11;
    }
}
