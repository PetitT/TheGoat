using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public GoatMovement control;
    public GameObject goat;
    public Transform goatMinY;
    public float fallSpeed;

    private void Start()
    {
        TimelineListener.instance.onControlShift += ControlShiftHandler;
    }

    private void ControlShiftHandler(bool canControl)
    {
        control.enabled = canControl;
        Debug.Log(canControl ? "Control Active" : "Control Inactive");
        if (!control.enabled)
            StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        while(goat.transform.position.y > goatMinY.position.y)
        {
            goat.transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
