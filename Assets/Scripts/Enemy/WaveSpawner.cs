using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    private void Start()
    {
        WaveManager.instance.waves.Add(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position+new Vector3(Random.Range(0f, 4f), 0, Random.Range(0f, 4f)), transform.rotation);
    }

    void EndSpawner()
    {
        WaveManager.instance.waves.Remove(this);
        CancelInvoke();
    }
}
