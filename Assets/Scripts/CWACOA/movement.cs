using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Rigidbody rb;
    private Vector3 moveDirection;
    private Animator animator;
    //Serialport serialPort = new SerialPort("COM6", 9600);
    // Update is called once per frame

    /*void Awake()
     * {
     *   serialPort.Open();
     *   serialPort.ReadTimeout = 1;
     * }*/

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //ProcessInputs();
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0, moveY);

        moveDirection.Normalize();

        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, Space.World);

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    /*
    private void FixedUpdate()
    {
        Move();
    }
    
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY);
    }

    private void Move()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0 ,moveDirection.y * moveSpeed);
    }*/
}
