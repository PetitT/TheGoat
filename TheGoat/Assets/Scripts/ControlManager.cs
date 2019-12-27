using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public GoatMovement control;

    private void Start()
    {
        TimelineListener.instance.onControlShift += ControlShiftHandler;
    }

    private void ControlShiftHandler(bool canControl)
    {
        control.enabled = canControl;
        Debug.Log(canControl ? "Control Active" : "Control Inactive");
    }
}
