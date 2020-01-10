using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHalo : MonoBehaviour
{
    private Behaviour halo;

    public static WolfHalo instance;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
    }

    public void ToggleHalo(bool toggle)
    {
        halo.enabled = toggle;
    }
}
