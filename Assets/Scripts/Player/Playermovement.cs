using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float mouseSpeed = 8f;
    private float gravity = -10f;
    private CharacterController cc;
    private Vector3 mov = Vector3.zero;


    private float mouseX;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.localEulerAngles = new Vector3(0, mouseX, 0);

        if (cc.isGrounded)
        {
            mov = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            mov = cc.transform.TransformDirection(mov);
        }

        else
        {
            mov.y += gravity * Time.deltaTime;
        }

        cc.Move(mov * Time.deltaTime * speed);

    }
}