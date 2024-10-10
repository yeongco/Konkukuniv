using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    bool WhatBullet = true;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject ShootPoint;


    public void OnChange()
    {
        WhatBullet = !WhatBullet;
    }

    public void OnFire()
    {
        if (WhatBullet)
        {
            GameObject clone = Instantiate(prefab1);
            clone.transform.position = ShootPoint.transform.position;
            clone.transform.rotation = ShootPoint.transform.rotation * Quaternion.Euler(90, 0, 0);
        }
        else
        {
            GameObject clone = Instantiate(prefab2);
            clone.transform.position = ShootPoint.transform.position;
            clone.transform.rotation = ShootPoint.transform.rotation;
        }


    }
}
