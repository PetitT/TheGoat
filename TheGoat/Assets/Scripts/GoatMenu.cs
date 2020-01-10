using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatMenu : MonoBehaviour
{
    public Transform left, right;
    private bool movingRight = true;
    public SpriteRenderer sprite;
    public float moveSpeed;

    private void Update()
    {
        transform.Translate((movingRight ? Vector2.right : Vector2.left) * moveSpeed * Time.deltaTime);

        if (transform.position.x >= right.position.x)
        {
            movingRight = false;
            sprite.flipX = true;
        }
        if (transform.position.x <= left.position.x)
        {
            movingRight = true;
            sprite.flipX = false;
        }
    }
}
