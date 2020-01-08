using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager instance;

    public PlayableDirector gameTimeline;
    public PlayableDirector gameOverTimeline;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        HealthManager.instance.onDeath += DeathHandler;        
    }

    private void DeathHandler()
    {
        GameOver();
    }

    public void GameOver()
    {
        gameTimeline.Stop();
        gameOverTimeline.Play();
    }

}
