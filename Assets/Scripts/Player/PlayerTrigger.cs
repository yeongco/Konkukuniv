using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{
    public Image black;
    public float FadeTime = 0.8f;
    // Start is called before the first frame update

    private void Start()
    {
        black.color = new Color(0,0,0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dark"))
        {
            StopAllCoroutines();
            StartCoroutine(Toblack());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dark"))
        {
            StopAllCoroutines();
            StartCoroutine(ToOrigin());
        }
    }

    IEnumerator Toblack()
    {
        float Dtime = 0f;
        float BAlpha = black.color.a;
        float ToColor = 0f;
        while (Dtime < FadeTime)
        {
            ToColor = Mathf.Lerp(BAlpha, 0.8f, Dtime/FadeTime);
            black.color = new Color(0, 0, 0, ToColor);
            Dtime += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0, 0, 0, 0.8f);
    }

    IEnumerator ToOrigin()
    {
        Debug.Log("ToOrigin");
        float Dtime = 0f;
        float ToColor = 0f;
        float BAlpha = black.color.a;
        while (Dtime < FadeTime)
        {
            ToColor = Mathf.Lerp(BAlpha, 0.0f, Dtime / FadeTime);
            black.color = new Color(0, 0, 0, ToColor);
            Dtime += Time.deltaTime;
            yield return null;
        }
        black.color = new Color(0,0,0,0);
    }
}
