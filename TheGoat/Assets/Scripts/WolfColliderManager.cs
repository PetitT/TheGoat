using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfColliderManager : MonoBehaviour
{
    public static WolfColliderManager instance;
    public PolygonCollider2D wolfCollider;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public void ToggleCollider(bool active)
    {
        wolfCollider.enabled = active;
    }
}
