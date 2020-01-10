using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource jojo, chill, bloodborne, soundSource;
    public AudioClip meeeh, goatDamage, leaf, wolfHowl, wolfGrowl, block, splat;

    public List<AudioClip> hitSounds;
    public float timeBetweenHits;
    public int numberOfHits;

    public enum Song { jojo, chill, bloodborne};
    public enum Sound { meeeh, goatDamage, leaf, wolfHowl, wolfGrowl, block, splat};    

    private Song currentSong;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

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

    public void PlaySound(Sound sound)
    {
        switch (sound)
        {
            case Sound.meeeh:
                soundSource.PlayOneShot(meeeh);
                break;
            case Sound.goatDamage:
                soundSource.PlayOneShot(goatDamage);
                break;
            case Sound.leaf:
                soundSource.PlayDelayed(-0.7f);
                break;
            case Sound.wolfHowl:
                soundSource.PlayOneShot(wolfHowl);
                break;
            case Sound.wolfGrowl:
                soundSource.PlayOneShot(wolfGrowl);
                break;
            case Sound.block:
                soundSource.PlayOneShot(block);
                break;
            case Sound.splat:
                soundSource.PlayOneShot(splat);
                break;
            default:
                break;
        }
    }

    public void SwordAttack()
    {
        StartCoroutine(Blades());
    }

    private IEnumerator Blades()
    {
        for (int i = 0; i < numberOfHits; i++)
        {
            int random = UnityEngine.Random.Range(0, hitSounds.Count);
            soundSource.PlayOneShot(hitSounds[random]);
            yield return new WaitForSeconds(timeBetweenHits);
        }
    }
}
