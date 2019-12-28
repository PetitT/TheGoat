using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchedToothBehaviour : MonoBehaviour
{
    private float damage;
    private float moveSpeed;
    private float rotationSpeed;
    private Vector2 direction;
    public GameObject image;

    private void Update()
    {
        Move();
        Rotate();
    }

    public void Initialize(float toothDamage, float toothMoveSpeed, float toothRotationSpeed, Vector2 toothDirection)
    {
        damage = toothDamage;
        moveSpeed = toothMoveSpeed;
        rotationSpeed = toothRotationSpeed;
        direction = toothDirection;
    }

    private void Move()
    {
        gameObject.transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        image.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
