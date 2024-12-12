using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForFire : MonoBehaviour
{
    public GameObject prefab;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = other.transform.position - new Vector3(0f, 0.5f, 0f);
            clone.transform.rotation = transform.rotation;
            other.GetComponent<AiEnemy>().Is_Dead = true;
            Destroy(other.gameObject, 2f);
        }
    }
}
