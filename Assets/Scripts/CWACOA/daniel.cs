using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daniel : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    [SerializeField] movement movementScript;
    public GameObject hola;
    private int patron;
    private float x;
    private float z;
    //Rigidbody rb;
    public Vector3 gravity;
    public float remainingTime;
    public float timeSinceMeteorSpawn;
    //public Vector3 fallVelocity;
    private Vector3 meteorSpawnPosition;
    private void Awake()
    {
        //rb = hola.gameObject.GetComponent<Rigidbody>();
        Physics.gravity = gravity;
        playerLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        remainingTime = Time.timeSinceLevelLoad;
        meteorSpawnPosition = playerLocation.position + Vector3.up * 30 + movementScript.moveDirection * movementScript.moveSpeed;
        if (meteorSpawnPosition.x < -9)
        {
            meteorSpawnPosition.x = -9;
        }
        if (meteorSpawnPosition.x > 9)
        {
            meteorSpawnPosition.x = 9;
        }
        if (meteorSpawnPosition.z < -9)
        {
            meteorSpawnPosition.z = -9;
        }
        if (meteorSpawnPosition.z > 9)
        {
            meteorSpawnPosition.z = 9;
        }

        if (remainingTime < 10)
        {
            StartCoroutine(timeBetween());
        }
        else
        {

        }
        
        /*if (Input.GetKey(KeyCode.H))
        {
            x = Random.Range(-11f, 11f);
            z = Random.Range(-12f, 12f);

            //rb.velocity = fallVelocity;
            Instantiate(hola, new Vector3(x, 30f, z), Quaternion.identity);
            
            //Instantiate(hola, new Vector3(0, 1, 0), Quaternion.identity);
        }*/
    }
    public IEnumerator timeBetween()
    {
        yield return new WaitForSeconds(timeSinceMeteorSpawn);
        //si la posicion en la que el meteorito spawnea esta fuera de los limites del deberia spawnear justo antes de la pared invisible limitando el eje x y z entre -9 y 9
        Instantiate(hola, meteorSpawnPosition, Quaternion.identity);
        StopAllCoroutines();
    }
}
