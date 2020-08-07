using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    [SerializeField] private Sprite trexSprite;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Animator anim;
    private string[] cheat = { "n", "a", "t", "h", "y" };
    private int cheatIndex = 0;
    private bool hasCheated = false;

    private void Update()
    {
        if (!hasCheated)
        {
            if (Input.anyKeyDown)
            {
                string input = Input.inputString;
                if (input == cheat[cheatIndex])
                {
                    cheatIndex++;
                    if (cheatIndex == cheat.Length)
                    {
                        ActivateCheat();
                        hasCheated = true;
                    }
                }
                else
                {
                    cheatIndex = 0;
                }
            }
        }
    }

    private void ActivateCheat()
    {
        anim.enabled = false;
        renderer.sprite = trexSprite;
        renderer.gameObject.transform.localScale = new Vector3(5, 5, 5);
        renderer.gameObject.transform.localPosition = new Vector3(0, 8.5f, 0);
        FindObjectOfType<HealthManager>().health = 100;
    }
}
