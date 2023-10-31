using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class perillaManager : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM6", 9600);
    GameObject perilla1;
    //GameObject perilla2;
    //GameObject perilla3;
    public Transform aaaaaaaaaaaa;


    // Start is called before the first frame update
    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            string value = serialPort.ReadLine();
            string[] pos = value.Split(',');
            Debug.Log(value);

            int perilla = Convert.ToInt32(pos[4]);

            aaaaaaaaaaaa.localEulerAngles = new Vector3(perilla, -90, -90);
        }
    }
}
