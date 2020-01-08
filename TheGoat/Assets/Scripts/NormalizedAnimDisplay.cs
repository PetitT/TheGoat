using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NormalizedAnimDisplay : MonoBehaviour
{
    public Animator anim;

    protected float maximum;
    protected float current;

    private void Start()
    {
        maximum = GetMaximum();
    }

    private void Update()
    {
        current = GetCurrent();
        DisplayAnim();
    }

    protected virtual void DisplayAnim()
    {
        float percent = 1 - (current / maximum);
        anim.SetFloat("Cooldown", percent);
    }

    protected abstract float GetCurrent();

    protected abstract float GetMaximum();

}
