using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject prefab;
    public float BulletSpeed = 10f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, BulletSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = other.transform.position - new Vector3(0f, 0.5f, 0f);
            clone.transform.rotation = transform.rotation;
            Destroy(other.gameObject, 0.3f);
            Destroy(gameObject);
        }
    }
}
