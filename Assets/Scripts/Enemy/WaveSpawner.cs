using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        Instantiate(prefab, transform.position+new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), transform.rotation);
    }

    void EndSpawner()
    {
        WaveManager.instance.waves.Remove(this);
        CancelInvoke();
    }
}
