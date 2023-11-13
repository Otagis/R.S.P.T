using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using Random = UnityEngine.Random;

public class perillaManager : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM6", 9600);
    public Transform perillaMovement1;
    public Transform perillaMovement2;
    public Transform perillaMovement3;
    public bool isComplete1;
    public bool isComplete2;
    public bool isComplete3;
    public int goal1;
    public int goal2;
    public int goal3;

    // Start is called before the first frame update
    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 1;
        isComplete1 = false;
        isComplete2 = false;
        isComplete3 = false;
        goal1 = Random.Range(0, 360);
        goal2 = Random.Range(0, 360);
        goal3 = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (serialPort.IsOpen)
        {
            string value = serialPort.ReadLine();
            string[] pos = value.Split(',');
            Debug.Log(value);

            int perilla1 = Convert.ToInt32(pos[4]);
            int perilla2 = Convert.ToInt32(pos[5]);
            int perilla3 = Convert.ToInt32(pos[6]);

            if (perilla1 == goal1)
            {
                isComplete1 = true;
            }

            if (isComplete1 == false)
            {
                perillaMovement1.localEulerAngles = new Vector3(0, perilla1, 0);
            }
            else if (isComplete1 == true)
            {
                perillaMovement1.localEulerAngles = new Vector3(0, goal1, 0);
            }
            
            if (perilla2 == goal2)
            {
                isComplete2 = true;
            }

            if (isComplete2 == false)
            {
                perillaMovement2.localEulerAngles = new Vector3(0, perilla2, 0);
            }
            else if (isComplete2 == true)
            {
                perillaMovement2.localEulerAngles = new Vector3(0, goal2, 0);
            }

            if (perilla3 == goal3)
            {
                isComplete3 = true;
            }

            if (isComplete3 == false)
            {
                perillaMovement3.localEulerAngles = new Vector3(0, perilla3, 0);
            }
            else if (isComplete3 == true)
            {
                perillaMovement3.localEulerAngles = new Vector3(0, goal3, 0);
            }
        }
        
    }

}
