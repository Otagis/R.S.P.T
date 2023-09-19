using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    private Vector3 moveDirection;
    //Serialport serialPort = new SerialPort("COM6", 9600);
    // Update is called once per frame
    
    /*void Awake()
     * {
     *   serialPort.Open();
     *   serialPort.ReadTimeout = 1;
     * }*/
    
    void Update()
    {
        ProcessInputs();
    }

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
    }
}
