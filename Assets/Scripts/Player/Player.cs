using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //public float leftRotorSpeed = 0.0f;
    //public float rightRotorSpeed = 0.0f;
    public float forwardSpeed = 1.0f;
    public float backwardSpeed = 0.5f;
    public float rotationspeed = 100.0f;
    
    public Rigidbody2D rb;

    public GameObject ParticleSyst1;
    public GameObject ParticleSyst2;

    private float y;
    private float x;

    //public Transform cameraloc;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSyst1.SetActive(true);
        ParticleSyst2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //processing inputs
        Move();
        //cameraloc.position = transform.position;
    }

    /// <summary>
    /// void: this function is called ever fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>

    void FixedUpdate()
    {
        //physics calculations
        //Move();
    }

    void Move()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal") * rotationspeed;
        Debug.Log("Left: " + y);
        Debug.Log("Right: " + x);
        rb.velocity = transform.up * y;
        transform.Rotate(0, 0, x * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * forwardSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.up * backwardSpeed);
        }

        if (rb.velocity.magnitude > forwardSpeed)
        {
            rb.velocity = (Vector2)Vector3.ClampMagnitude((Vector3)rb.velocity, forwardSpeed);
        }
        if (rb.velocity.magnitude > backwardSpeed)
        {
            rb.velocity = (Vector2)Vector3.ClampMagnitude((Vector3)rb.velocity, backwardSpeed);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationspeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationspeed * Time.deltaTime);
        }
    }
}