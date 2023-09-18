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

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public GameObject fManager;
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
            if (/*(Convert.ToInt32(Botn[0]))*/ Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = jumpSpeed;
                isGrounded = false;
                transform.localScale = new Vector3(1, 2, 1);
            }
            if (/*(Convert.ToInt32(Botn[0]))*/ Input.GetKey(KeyCode.W) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = jumpSpeed;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                isJumping = false;
            }
            if (/*(Convert.ToInt32(Botn[1])) == 0*/ Input.GetKey(KeyCode.S) && isGrounded)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isSliding = true;
            }
            else if (isGrounded)
            {
                transform.localScale = new Vector3(1, 2, 1);
                if (isSliding == true)
                {
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
        else if (collision.gameObject.CompareTag("redFlag"))
        {
            transform.Rotate(0, 180, 0);
            fManager.GetComponent<flagChanger>().Flags[2].SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
