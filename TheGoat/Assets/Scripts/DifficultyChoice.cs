using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChoice : MonoBehaviour
{
    public int difficulty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<StartGame>().Begin(difficulty);
    }
}
