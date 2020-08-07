using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicSkip : MonoBehaviour
{
    [SerializeField] private float timeScaleBuff;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = timeScaleBuff;
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
