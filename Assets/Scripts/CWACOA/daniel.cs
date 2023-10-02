using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daniel : MonoBehaviour
{
    public GameObject hola;
    private int patron;
    private float x;
    private float z;
    //Rigidbody rb;
    public Vector3 gravity;
    //public Vector3 fallVelocity;
    private void Awake()
    {
        //rb = hola.gameObject.GetComponent<Rigidbody>();
        Physics.gravity = gravity;
    }

    void Update()
    {
        if (patron == 0)
        {
            x = 11;
            z = -11;

            for (int i = 0; i < 8; i++)
            {
                Instantiate(hola, new Vector3(x, 30f, z), Quaternion.identity);
                x = x - 3;
                z = z + 3;
            }
            patron = 1;
        }
        else if (patron == 1)
        {

        }
        else if (patron == 2)
        {

        }
        else if (patron == 3)
        {

        }
        if (Input.GetKey(KeyCode.H))
        {
            /*x = Random.Range(-11f, 11f);
            z = Random.Range(-12f, 12f);

            //rb.velocity = fallVelocity;
            Instantiate(hola, new Vector3(x, 30f, z), Quaternion.identity);
            
            //Instantiate(hola, new Vector3(0, 1, 0), Quaternion.identity);*/
            patron = 0;
        }
    }
}
