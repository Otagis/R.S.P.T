using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daniel : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    public GameObject hola;
    private int patron;
    private float x;
    private float z;
    //Rigidbody rb;
    public Vector3 gravity;
    public float remainingTime;
    public float timeSinceMeteorSpawn;
    //public Vector3 fallVelocity;
    private void Awake()
    {
        //rb = hola.gameObject.GetComponent<Rigidbody>();
        Physics.gravity = gravity;
    }

    void Update()
    {
        remainingTime = Time.timeSinceLevelLoad;

        if (remainingTime < 10)
        {

        }
        else
        
        /*if (Input.GetKey(KeyCode.H))
        {
            x = Random.Range(-11f, 11f);
            z = Random.Range(-12f, 12f);

            //rb.velocity = fallVelocity;
            Instantiate(hola, new Vector3(x, 30f, z), Quaternion.identity);
            
            //Instantiate(hola, new Vector3(0, 1, 0), Quaternion.identity);
        }*/
    }
}
