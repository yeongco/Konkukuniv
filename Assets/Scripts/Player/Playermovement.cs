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

    private Vector2 movementValue;
    private float lookValue;


    // Start is called before the first frame update

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
    }

}