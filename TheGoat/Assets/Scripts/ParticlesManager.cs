using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public ParticleSystem bigBloodParticles;
    public ParticleSystem blockParticles;
    public ParticleSystem grassParticles;
    public ParticleSystem smallBloodParticles;

    public static ParticlesManager instance;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public void PlaySmallBlood()
    {
        smallBloodParticles.Play();
    }

    public void PlayBigBlood()
    {
        bigBloodParticles.Play();
    }

    public void PlayBlock()
    {
        blockParticles.Play();
    }

    public void PlayGrass()
    {
        grassParticles.Play();
    }


}
