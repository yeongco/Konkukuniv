using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int amount = 0;
    private float GameTime = 30f;
    private float CurrentTime = 0f;
    public Text Timer;
    public Text Score;
    public Image img;
    bool Is_Win = false;
    bool TimeOver = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        CurrentTime = GameTime;
    }

    public void Update()
    {
        if(amount>100 && PlayerManager.instance.HP > 0) Is_Win = true;
        if (PlayerManager.instance.HP <= 0)
        {
            Is_Win = false;
            if (TimeOver == false)
            {
                TimeOver = true;
                StartCoroutine(End_UI(img));
            }
        }
        if (!TimeOver)
            SetTime();
    }

    void Result()
    {
        Cursor.lockState = CursorLockMode.None;
        if (Is_Win)
            SceneManager.LoadScene("Win");
        else
            SceneManager.LoadScene("Lose");
    }

    void SetTime()
    {
        if ((CurrentTime > 0f))
        {
            CurrentTime -= Time.deltaTime;
        }
        else
            CurrentTime = 0f;
        string formatted = CurrentTime.ToString("F2");
        if (CurrentTime != 0f)
            Timer.text = formatted.Replace('.', ':');
        else
        {
            if (Timer == null || Score == null || img == null)
                return;
            TimeOver = true;
            Timer.text = "Time Over!!!!!!";
            StartCoroutine(End_UI(img));
        }
    }

    public void SetScore()
    {
        if (Timer == null || Score == null || img == null)
            return;
        string formatted = amount.ToString("D3");
        Score.text = "Score : " + formatted;
    }

    IEnumerator End_UI(Image img)
    {
        float Dtime = 0f;
        Color c = Is_Win ? Color.blue : Color.red;
        img.color = new Color(c.r, c.g, c.b, 0f);
        float BAlpha = 0f;
        float ToColor = 0f;
        while (Dtime < 1f)
        {
            ToColor = Mathf.Lerp(BAlpha, 1f, Dtime / 1f);
            img.color = new Color(c.r, c.g, c.b, ToColor);
            Dtime += Time.deltaTime;
            yield return null;
        }
        img.color = c;
        Result();
    }
}
