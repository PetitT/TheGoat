using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource jojo, chill, bloodborne;

    public enum Song { jojo, chill, bloodborne};

    private Song currentSong;

    private void Start()
    {
        TimelineListener.instance.onSongChange += SongChangeHandler;
        jojo.time = 226f;
        bloodborne.time = 5f;
    }

    private void SongChangeHandler(Song obj)
    {
        jojo.Pause();
        chill.Pause();
        bloodborne.Pause();

        switch (obj)
        {
            case Song.jojo:
                jojo.Play();
                break;
            case Song.chill:
                chill.Play();
                break;
            case Song.bloodborne:
                bloodborne.Play();
                break;
            default:
                break;
        }
    }
}
