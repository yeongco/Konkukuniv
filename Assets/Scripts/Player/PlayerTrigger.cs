using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{
    public Image FadeImage;
    public float FadeTime = 0.8f;
    public static PlayerTrigger instance;
    // Start is called before the first frame update

    private void Start()
    {
        instance = this;
        FadeImage.color = new Color(0,0,0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dark"))
        {
            StopAllCoroutines();
            StartCoroutine(ToColor(Color.black, FadeTime));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dark"))
        {
            StopAllCoroutines();
            StartCoroutine(ToOrigin(FadeTime));
        }
    }

    IEnumerator ToColor(Color c, float fadetime)
    {
        float Dtime = 0f;
        FadeImage.color = c;
        float BAlpha = FadeImage.color.a;
        float ToColor = 0f;
        while (Dtime < fadetime)
        {
            ToColor = Mathf.Lerp(BAlpha, 0.8f, Dtime/fadetime);
            FadeImage.color = new Color(c.r, c.g, c.b, ToColor);
            Dtime += Time.deltaTime;
            yield return null;
        }
        FadeImage.color = new Color(c.r, c.g, c.b, 0.8f);
    }

    IEnumerator ToOrigin(float fadetime)
    {
        Debug.Log("ToOrigin");
        Color c = FadeImage.color;
        float Dtime = 0f;
        float ToColor = 0f;
        float BAlpha = FadeImage.color.a;
        while (Dtime < fadetime)
        {
            ToColor = Mathf.Lerp(BAlpha, 0.0f, Dtime / fadetime);
            FadeImage.color = new Color(c.r, c.g, c.b, ToColor);
            Dtime += Time.deltaTime;
            yield return null;
        }
        FadeImage.color = new Color(0,0,0,0);
    }
}
