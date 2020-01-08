using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{

    public float slowdownTime;
    public float slowdownForce;

    private void Start()
    {
        HealthManager.instance.onDeath += DeathHandler;
    }

    private void DeathHandler()
    {
        ParticlesManager.instance.PlayBigBlood();
        StartCoroutine(Slowdown());
    }

    private IEnumerator Slowdown()
    {
        Time.timeScale = slowdownForce;
        yield return new WaitForSecondsRealtime(slowdownTime);
        Time.timeScale = 1;
    }
}
