using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public List<GameObject> hearts;
    public List<float> heartSpeed;
    private int CurrentHeart;

    private void Start()
    {
        CurrentHeart = hearts.Count - 1;
        GoatCollisionManager.instance.onDamageTaken += DamageTakenHandler;
        SetAnimation();
    }

    private void DamageTakenHandler()
    {
        hearts[CurrentHeart].SetActive(false);
        CurrentHeart--;
        if (CurrentHeart >= 0)
        {
            SetAnimation();
        }
    }

    private void SetAnimation()
    {
        Animator anim = hearts[CurrentHeart].GetComponentInChildren<Animator>();
        anim.enabled = true;
        anim.SetFloat("Speed", heartSpeed[CurrentHeart]);
    }
}
