using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothLaunch : BaseAttack
{
    public Transform launchOrigin;
    public GameObject tooth;
    public float moveSpeed;
    public float rotationSpeed;
    public float damage;

    public override void Attack()
    {
        GameObject newTooth = Pool.instance.GetItemFromPool(tooth, launchOrigin.position);
        newTooth.GetComponent<LaunchedToothBehaviour>().Initialize(damage, moveSpeed, rotationSpeed, LookAtGoat.instance.lookingLeft? Vector2.left : Vector2.right);
    }
}
