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
    private Vector3 moveDirection;
    SerialPort serialPort = new SerialPort("COM6", 9600);
    // Update is called once per frame

    void Awake()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 1;
    }

    void Update()
    {
        if(serialPort.IsOpen)
        {
            string value = serialPort.ReadLine();
            string[] move = value.Split(',');

            int x = Convert.ToInt32(move[2]);
            int y = Convert.ToInt32(move[3]);

            if (x != -1 && x > 0)
            {
                transform.Translate(0.4f, 0, 0);
            }
            if (x != -1 && x < 0)
            {
                transform.Translate(-0.4f, 0, 0);
            }
            if (y != -1 && y > 0)
            {
                transform.Translate(0, 0, -0.4f);
            }
            if (y != -1 && y < 0)
            {
                transform.Translate(0, 0, 0.4f);
            }
            if (x != -1 && y != -1 && x > 0 && y > 0)
            {
                transform.Translate(0.2f, 0, -0.2f);
            }
            if (x != -1 && y != -1 && x < 0 && y > 0)
            {
                transform.Translate(-0.2f, 0, -0.2f);
            }
            if (x != -1 && y != -1 && x > 0 && y < 0)
            {
                transform.Translate(0.2f, 0, 0.2f);
            }
            if (x != -1 && y != -1 && x < 0 && y < 0)
            {
                transform.Translate(-0.2f, 0, 0.2f);
            }

        }
    } 
    

}
