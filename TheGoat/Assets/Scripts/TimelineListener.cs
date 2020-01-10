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
    public event Action onWolfLastWords;
    public event Action onGameReset;
    public event Action<SoundManager.Song> onSongChange;

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

    public void WolfLastWords()
    {
        onWolfLastWords?.Invoke();
    }

    public void ResetGame()
    {
        onGameReset?.Invoke();
    }

    public void PlayJoJo()
    {
        onSongChange(SoundManager.Song.jojo);
    }

    public void PlayChill()
    {
        onSongChange(SoundManager.Song.chill);
    }

    public void PlayBloodborne()
    {
        onSongChange(SoundManager.Song.bloodborne);
    }

    public void SoundGrowl()
    {
        SoundManager.instance.PlaySound(SoundManager.Sound.wolfGrowl);
    }
    
    public void SoundMeeh()
    {
        SoundManager.instance.PlaySound(SoundManager.Sound.meeeh);
    }
}
