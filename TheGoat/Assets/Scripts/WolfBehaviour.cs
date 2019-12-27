using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    private void Awake()
    {
        TimelineListener.instance.onPhaseChange += PhaseChangeListener;
    }

    private void PhaseChangeListener()
    {
        Debug.Log("Phase Changed");
    }
}
