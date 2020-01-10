using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public PlayableDirector timeline;

    private void Update()
    {
        if (Input.anyKey)
            timeline.Play();
    }

    public void Begin()
    {
        SceneManager.LoadScene(1);
    }

}
