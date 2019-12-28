using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtGoat : MonoBehaviour
{
    public static LookAtGoat instance;

    public Transform goat;
    public SpriteRenderer sprite;
    [HideInInspector] public bool lookingLeft = true;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        AdjustDirection();
    }

    private void AdjustDirection()
    {
        float wolfX = transform.position.x;
        float goatX = goat.position.x;

        if (lookingLeft)
        {
            if (wolfX < goatX)
            {
                gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
                lookingLeft = false;
            }
        }
        else
        {
            if (wolfX > goatX)
            {
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                lookingLeft = true;
            }
        }
    }
}
