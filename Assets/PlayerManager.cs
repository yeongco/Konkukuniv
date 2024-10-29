using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public short HP = 5;
    public Text t;
    public bool IsHit = false;

    private void Awake()
    {
        HP = 5;
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
    }
}
