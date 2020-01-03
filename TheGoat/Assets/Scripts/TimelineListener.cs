using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineListener : MonoBehaviour
{

    public static TimelineListener instance;

    public event Action onPhaseChange;
    public event Action<bool> onControlShift;
    public event Action onGoatTalk;
    public event Action onWolfTalk;
    public event Action onNarratorTalk;
    public event Action<WolfState> onWolfStateChange;

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

    public void ControlShift(bool canControl)
    {
        onControlShift?.Invoke(canControl);
    }

    public void GoatTalk()
    {
        onGoatTalk?.Invoke();
    }

    public void WolfTalk()
    {
        onWolfTalk?.Invoke();
    }

    public void NarratorTalk()
    {
        onNarratorTalk?.Invoke();
    }

    public void WolfStateIdle()
    {
        onWolfStateChange?.Invoke(WolfState.idle);
    }

    public void WolfStateAttack()
    {
        onWolfStateChange?.Invoke(WolfState.attacking);
    }

    public void WolfStateVulnerable()
    {
        onWolfStateChange?.Invoke(WolfState.vulnerable);
    }

}
