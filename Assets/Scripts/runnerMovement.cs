using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class runnerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 gravity;
    public Vector3 jumpSpeed;
    public float speed;

    Rigidbody rb;
    bool isGrounded = false;
    bool isSliding = false;
    //SerialPort serialPort = new SerialPort("COM6", 9600);
    void Awake()
    {
        //serialPort.Open();
        //serialPort.ReadTimeout = 1;
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(serialPort.IsOpen)
        //{
            //string value = serialPort.ReadLine();
            //string[] Botn = value.Split(',');

            transform.Translate(speed, 0, 0);
            if (/*(Convert.ToInt32(Botn[0]))*/ Input.GetKeyDown(KeyCode.S) && isGrounded)
            {
                rb.velocity = jumpSpeed;
                isGrounded = false;
            }
            if (/*(Convert.ToInt32(Botn[1])) == 0*/ Input.GetKey(KeyCode.A) && isGrounded)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
                isSliding = true;
            }
            else if (isGrounded)
            {
                transform.localScale = new Vector3(1, 2, 1);
                if (isSliding = true)
                {
                    transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
                    isSliding = false;
                }
                
            }
        //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("meta"))
        {
            speed = 0;
            Destroy(collision.gameObject);
        }
    }
}
