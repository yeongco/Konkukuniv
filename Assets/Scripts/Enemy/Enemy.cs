using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int score = 5;
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.instance.enemies.Add(this);
    }

    private void OnDestroy()
    {
        ScoreManager.instance.amount += score;
        EnemyManager.instance.enemies.Remove(this);
    }

    // Update is called once per frame
}
