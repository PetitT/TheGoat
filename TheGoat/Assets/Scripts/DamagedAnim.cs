using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamagedAnim : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int numberOfBlinks;
    public float blinkFrequency;

    protected void DamagedHandler()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        for (int i = 0; i < numberOfBlinks * 2; i++)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(blinkFrequency);
        }
        sprite.enabled = true;
    }
}
