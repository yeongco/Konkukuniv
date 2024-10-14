using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering.LookDev;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public bool IsRun = false;
    [SerializeField] float Walkspeed = 7f;
    [SerializeField] float Runspeed = 10f;
    public float speed;
    [SerializeField] float mouseSpeed = 8f;

    public GameObject Camera;

    private Vector3 movementValue;
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

        rb.AddRelativeForce(movementValue * speed);

        rb.AddRelativeTorque(0, lookValue * Time.deltaTime, 0);

        mouseY = Mathf.Clamp(mouseY, -50f, 30f);
        Camera.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }

    public void OnMove(InputValue v)
    {
        Vector2 input = v.Get<Vector2>().normalized;
        if(input != null)
        {
            movementValue = new Vector3(input.x, 0f, input.y);
        }
    }

/*    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsRun = !IsRun;
            Debug.Log(IsRun);
        }
    }*/

    public void OnLook(InputValue v)
    {
        lookValue = v.Get<Vector2>().x * mouseSpeed;
        mouseY += v.Get<Vector2>().y * 0.1f;
    }

}