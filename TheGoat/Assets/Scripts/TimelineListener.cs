using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineListener : MonoBehaviour
{

    public static TimelineListener instance;

    public event Action onPhaseChange;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public void PhaseChange()
    {
        onPhaseChange?.Invoke();
    }


}
