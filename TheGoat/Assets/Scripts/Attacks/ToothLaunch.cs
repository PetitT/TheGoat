﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothLaunch : BaseAttack
{
    public List<Transform> launchOrigins;
    public GameObject tooth;
    public float moveSpeed;
    public float rotationSpeed;
    public float lifeTime;
    public float windupTime;

    public override void Attack()
    {
        WolfAnimManager.instance.Attack();
        StartCoroutine("Windup");
    }

    private IEnumerator Windup()
    {
        yield return new WaitForSeconds(windupTime);
        GameObject newTooth = Pool.instance.GetItemFromPool(tooth, GetRandomPosition());
        newTooth.GetComponent<LaunchedToothBehaviour>().Initialize(lifeTime, moveSpeed, rotationSpeed, LookAtGoat.instance.lookingLeft? Vector2.left : Vector2.right);
        yield return new WaitForSeconds(windupTime);
        AttackFinished();
    }

    private Vector2 GetRandomPosition()
    {
        int random = UnityEngine.Random.Range(0, launchOrigins.Count);
        return launchOrigins[random].position;
    }
}
