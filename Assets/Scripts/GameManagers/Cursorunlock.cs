using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursorunlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("cursorunlocker", 2f);
    }

    private void cursorunlocker()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
