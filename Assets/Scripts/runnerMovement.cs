using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 gravity;
    public Vector3 jumpSpeed;
    public float speed;

    Rigidbody rb;
    bool isGrounded = false;
    void Awake()
    {
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = jumpSpeed;
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.S) && isGrounded)
        { 
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
        else
        {
            transform.localScale = new Vector3(1, 2, 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
