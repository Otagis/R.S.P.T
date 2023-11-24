using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daniel : MonoBehaviour
{
    [SerializeField] Transform playerLocation;
    [SerializeField] movement movementScript;
    public GameObject hola;
    public GameObject fpi;
    private int patron;
    private float x;
    private float z;
    //Rigidbody rb;
    public Vector3 gravity;
    private float remainingTime;
    public float timeBeforeCompletion;
    public float timeSinceMeteorSpawn;
    //public Vector3 fallVelocity;
    private Vector3 meteorSpawnPosition;
    private bool lost;
    private void Awake()
    {
        //rb = hola.gameObject.GetComponent<Rigidbody>();
        Physics.gravity = gravity;
        playerLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lost = false;
    }

    void Update()
    {
        remainingTime = Time.timeSinceLevelLoad;
        if (lost == false)
        {
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
        }
            
        else
            meteorSpawnPosition = new Vector3 (100, 0, 100);

        if (remainingTime < timeBeforeCompletion)
        {
            StartCoroutine(timeBetween());
        }
        if (remainingTime >= timeBeforeCompletion && lost == false)
        {
            SceneLoader.instance.OnWin();
            lost = true;
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
        Instantiate(fpi, meteorSpawnPosition - Vector3.up * 29.78f, Quaternion.identity);
        Instantiate(hola, meteorSpawnPosition, Quaternion.identity);
        StopAllCoroutines();
    }
    public void ConfirmedDeath()
    {
        lost = true;
        timeBeforeCompletion = 0;
    }
}
