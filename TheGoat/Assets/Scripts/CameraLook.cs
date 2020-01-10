using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform target;
    public float XDiff = 0;
    public float YDiff;
    public float ZDiff;

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x + XDiff, target.transform.position.y +YDiff, ZDiff);
    }
}
