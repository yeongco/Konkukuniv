using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    bool IsRun = false;
    [SerializeField] float Walkspeed = 7f;
    [SerializeField] float Runspeed = 10f;
    float speed;
    [SerializeField] float mouseSpeed = 8f;
    private float gravity = -10f;

    public GameObject Camera;

    private Vector2 movementValue;
    private float lookValue;
    private float mouseY;


    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRun)
            speed = Runspeed;
        else speed = Walkspeed;

        transform.Translate(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime);

        transform.Rotate(0, lookValue * Time.deltaTime, 0);

        mouseY = Mathf.Clamp(mouseY, -50f, 30f);
        Camera.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }

    public void OnMove(InputValue v)
    {
        movementValue = v.Get<Vector2>()*speed;
    }

    public void OnDash()
    {
        IsRun = !IsRun;
        Debug.Log(IsRun);
    }

    public void OnLook(InputValue v)
    {
        lookValue = v.Get<Vector2>().x * mouseSpeed;
        mouseY += v.Get<Vector2>().y * 0.1f;
    }

}