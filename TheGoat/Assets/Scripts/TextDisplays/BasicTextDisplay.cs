using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BasicTextDisplay : MonoBehaviour
{
    public TextData data;
    public TextMeshPro tmp;
    public float timeToDisplayText;

    private int currentText = 0;

    protected void DisplayTextHandler()
    {
        StartCoroutine("DisplayText");
    }

    private IEnumerator DisplayText()
    {
        tmp.text = data.texts[currentText];
        currentText++;
        yield return new WaitForSeconds(timeToDisplayText);
        tmp.text = "";
    }
}
