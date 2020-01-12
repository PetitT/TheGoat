using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public PlayableDirector timeline;

    public int scene = 0;

    public void Begin(int number)
    {
        scene = number;
        timeline.Play();
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(scene);
    }
}
