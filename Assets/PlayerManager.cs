using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public short MaxHP = 5;
    public short HP = 5;
    public Text t;
    public bool IsHit = false;
    public Image HitUI;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        HP = MaxHP;
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        t.text = "HP : " + PlayerManager.instance.HP;
    }

    public void LooseHP()
    {   
        if (!IsHit)
        {
            IsHit = true;
            OnHit();

            StartCoroutine(HitDelay());
            StartCoroutine(Hiteffect(Color.red));
        }
    }

    IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(2.0f);
        IsHit = false;
    }

    public void OnHit()
    {
        HP--;
        SoundManager.Instance.PlaySFX("Heaten");
    }

    IEnumerator Hiteffect(Color c)
    {
        float Dtime = 0f;
        HitUI.color = c;
        float BAlpha = HitUI.color.a;
        float ToColor = 0f;
        while (Dtime < 0.1f)
        {
            ToColor = Mathf.Lerp(BAlpha, 0.8f, Dtime / 0.2f);
            HitUI.color = new Color(c.r, c.g, c.b, ToColor);
            Dtime += Time.deltaTime;
            yield return null;
        }
        while (Dtime < 0.3f)
        {
            ToColor = Mathf.Lerp(BAlpha, 0.0f, Dtime / 0.3f);
            HitUI.color = new Color(c.r, c.g, c.b, ToColor);
            Dtime += Time.deltaTime;
            yield return null;
        }
        HitUI.color = new Color(0, 0, 0, 0);
    }
}
