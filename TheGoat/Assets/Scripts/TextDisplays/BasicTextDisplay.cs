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

    public void DisplaySpecificText(string text)
    {
        StartCoroutine(SpecificText(text));
    }

    private IEnumerator SpecificText(string text)
    {
        tmp.text = text;
        yield return new WaitForSeconds(timeToDisplayText);
        tmp.text = "";
    }

    private IEnumerator DisplayText()
    {
        tmp.text = data.texts[currentText];
        currentText++;
        yield return new WaitForSeconds(timeToDisplayText);
        tmp.text = "";
    }
}
