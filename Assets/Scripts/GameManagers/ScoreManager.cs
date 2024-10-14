using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int amount = 0;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        Invoke("Result", 23f);
    }

    void Result()
    {
        if (amount > 100)
            SceneManager.LoadScene("Win");
        else
            SceneManager.LoadScene("Lose");
    }
}
