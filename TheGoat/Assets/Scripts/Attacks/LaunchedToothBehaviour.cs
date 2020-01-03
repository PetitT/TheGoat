using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchedToothBehaviour : MonoBehaviour
{
    private float damage;
    private float moveSpeed;
    private float rotationSpeed;
    private float lifeTime;
    private Vector2 direction;
    public GameObject image;
    private bool hasInitialized = false;

    private void Update()
    {
        if (hasInitialized)
        {
            Move();
            Rotate();
            CountDown();
        }
    }

    public void Initialize(float toothLifetime, float toothMoveSpeed, float toothRotationSpeed, Vector2 toothDirection)
    {
        moveSpeed = toothMoveSpeed;
        rotationSpeed = toothRotationSpeed;
        direction = toothDirection;
        lifeTime = toothLifetime;
        hasInitialized = true;
    }

    private void Move()
    {
        gameObject.transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        image.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
    }

    private void CountDown()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            hasInitialized = false;
            gameObject.SetActive(false);
        }
    }
}
