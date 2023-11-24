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

    public GameObject goal;
    private Animator animator;
    private CapsuleCollider collider;
    //SerialPort serialPort = new SerialPort("COM6", 9600);
    void Awake()
    {
        //serialPort.Open();
        //serialPort.ReadTimeout = 1;
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>(); 
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        //if(serialPort.IsOpen)
        //{
            //string value = serialPort.ReadLine();
            //string[] Botn = value.Split(',');
            if (Input.GetKeyDown(KeyCode.H))
                SceneLoader.instance.OnWin();
            if (Input.GetKey(KeyCode.J))
                transform.Translate(speed * Time.deltaTime, 0, 0);
            if (/*(Convert.ToInt32(Botn[0]))*/ Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = jumpSpeed;
                isGrounded = false;
                animator.SetBool("isJumping", true);
                animator.SetBool("isSliding", false);
                collider.height = 2;
                collider.center = new Vector3 (0, 1, 0);
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
                collider.height = 1;
                collider.center = new Vector3 (0, 0.5f, 0);
                animator.SetBool("isSliding", true);
                animator.SetBool("isJumping", false);
                isSliding = true;
            }
            else if (isGrounded)
            {
                animator.SetBool("isJumping", false);
                if (isSliding == true)
                {
                    isSliding = false;
                    animator.SetBool("isSliding", false);
                }
                collider.height = 2;
                collider.center = new Vector3 (0, 1, 0);
            }
        //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnDeath();
        }
        else if (collision.gameObject.CompareTag("meta"))
        {
            speed = 0;
            Destroy(collision.gameObject);
            animator.SetBool("isRunning", false);
            SceneLoader.instance.OnWin();
        }
        else if (collision.gameObject.CompareTag("redFlag"))
        {
            transform.Rotate(0, 180, 0);
            Destroy(collision.gameObject);
            Instantiate(goal, new Vector3(0, 2.5f, 0), Quaternion.identity);
        }
    }

    public void OnDeath()
    {
        speed = 0;
        jumpSpeed = new Vector3 (0, 0, 0);
        animator.SetBool("death", true);
        SceneLoader.instance.OnLose();
    }
}
