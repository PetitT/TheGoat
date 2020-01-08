using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    private void Start()
    {
        TimelineListener.instance.onGameReset += GameResetHandler;
    }

    private void GameResetHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
