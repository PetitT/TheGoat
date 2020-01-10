using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public static WinGame instance;

    public ParticleSystem wolfBlood;
    public SpriteRenderer wolf;
    public float slowForce;
    public float slowDuration;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public void Win()
    {
        StartCoroutine(Won());
    }

    private IEnumerator Won()
    {
        wolfBlood.Play();
        Time.timeScale = slowForce;
        yield return new WaitForSecondsRealtime(slowDuration);
        wolf.enabled = false;
        Time.timeScale = 1f;
    }
}
