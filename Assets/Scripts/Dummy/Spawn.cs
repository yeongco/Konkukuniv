using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawning", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    void Spawning()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
