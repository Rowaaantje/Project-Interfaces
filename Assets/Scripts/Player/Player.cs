using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float leftRotorSpeed;
    public float rightRotorSpeed;
    
    public Rigidbody2D rb;

    public GameObject leftRotor;
    public GameObject rightRotor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //processing inputs
        Move();
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
        if (leftRotorSpeed <= 5)
        {
            //Left Rotor speed forwards
            if (Input.GetKey(KeyCode.W))
            {
                leftRotorSpeed += (float)0.01;
            }
        } 
        if (rightRotorSpeed <= 5)
        {
            //Right Rotor speed forwards
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rightRotorSpeed += (float)0.01;
            }
        }

        if (leftRotorSpeed >= -2 )
        {
            //Left Rotor speed backwards
            if (Input.GetKey(KeyCode.S))
            {
                leftRotorSpeed -= (float)0.01;
            }
        }
        if (rightRotorSpeed >= -2)
        {
            //Right Rotor speed backwards
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rightRotorSpeed -= (float)0.01;
            }
        }

        if (rightRotorSpeed >= 0 && leftRotorSpeed >= 0)
        {
            rb.AddForce(transform.up * (rightRotorSpeed + leftRotorSpeed));
        }

        if (rightRotorSpeed >= leftRotorSpeed)
        {
            rb.AddForce(transform.up * rightRotorSpeed);
            rb.rotation -= leftRotorSpeed;
        }
        if (rightRotorSpeed <= leftRotorSpeed)
        {
            rb.AddForce(transform.up * leftRotorSpeed);
            rb.rotation += rightRotorSpeed;
        }

        if (leftRotorSpeed <= 0 && rightRotorSpeed <= 0)
        {
            rb.AddForce(transform.up * (rightRotorSpeed + leftRotorSpeed));
        }

    }
}