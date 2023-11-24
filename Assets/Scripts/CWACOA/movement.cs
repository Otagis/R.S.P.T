using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Rigidbody rb;
    public Vector3 moveDirection;
    private Animator animator;
    //SerialPort serialPort = new SerialPort("COM6", 9600);
    // Update is called once per frame

    //void Awake()
    //{
    //    serialPort.Open();
    //    serialPort.ReadTimeout = 1;
    //}

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            //if (serialPort.IsOpen)
            //{
            //    string value = serialPort.ReadLine();
            //    string[] move = value.Split(',');

            //    int x = Convert.ToInt32(move[2]);
            //    int y = Convert.ToInt32(move[3]);

            //    if (x != -1 && x > 0)
            //    {
            //        transform.Translate(-0.6f, 0, 0);
            //        animator.SetBool("isMoving", true);
                    
            //    }
            //    if (x != -1 && x < 0)
            //    {
            //        transform.Translate(0.6f, 0, 0);
            //        animator.SetBool("isMoving", true);
            //    }
            //    if (y != -1 && y > 0)
            //    {
            //        transform.Translate(0, 0, -0.6f);
            //        animator.SetBool("isMoving", true);
            //    }
            //    if (y != -1 && y < 0)
            //    {
            //        transform.Translate(0, 0, 0.6f);
            //        animator.SetBool("isMoving", true);
            //    }
            //    if (x != -1 && y != -1 && x > 0 && y > 0)
            //    {
            //        transform.Translate(-0.2f, 0, -0.2f);
            //        animator.SetBool("isMoving", true);
            //    }
            //    if (x != -1 && y != -1 && x < 0 && y > 0)
            //    {
            //        transform.Translate(0.2f, 0, -0.2f);
            //        animator.SetBool("isMoving", true);
            //    }
            //    if (x != -1 && y != -1 && x > 0 && y < 0)
            //    {
            //        transform.Translate(-0.2f, 0, 0.2f);
            //        animator.SetBool("isMoving", true);
            //    }
            //    if (x != -1 && y != -1 && x < 0 && y < 0)
            //    {
            //        transform.Translate(0.2f, 0, 0.2f);
            //        animator.SetBool("isMoving", true); 
            //    }
            //    else
            //    {
            //        animator.SetBool("isMoving", true);
            //    }

            //}


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

        public void OnDeath()
        {
        //serialPort.Close();
        moveSpeed = 0;
        rotationSpeed = 0;
        animator.SetBool("death", true);
        SceneLoader.instance.OnLose();
        }
}
