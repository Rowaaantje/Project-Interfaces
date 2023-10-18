using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTest : MonoBehaviour
{
    public Rigidbody2D Ship;
    public float MaxRotation;
    public float ThrustSpeed;
    public float Thrust;
    private float RotationSpeed;
    private float LeftThrust;
    private float RightThrust;
    private float RotateThrustSpeed = 0.25f;


    void Start()
    {
    }

    void Update()
    {
        /*LeftThrust = Input.GetAxis("Left") * MaxRotation;
        RightThrust = Input.GetAxis("Right") * MaxRotation;*/
        if (Input.GetKey("e") && RightThrust < MaxRotation)
        {
            RightThrust += RotateThrustSpeed;
        }
        if (Input.GetKey("d") && RightThrust > -MaxRotation)
        {
            RightThrust -= RotateThrustSpeed;

        }
        if (Input.GetKey("w") && LeftThrust < MaxRotation)
        {
            LeftThrust += RotateThrustSpeed;
        }
        if (Input.GetKey("s") && LeftThrust > -MaxRotation)
        {
            LeftThrust -= RotateThrustSpeed;
        }
        RotationSpeed = RightThrust + (LeftThrust * -1);
        Ship.rotation += RotationSpeed * Time.deltaTime;
        if (LeftThrust + RightThrust > 0)
        {
            Thrust = (((float)math.pow(x: LeftThrust + RightThrust, y: Math.Sqrt(3)))*0.0015f)*ThrustSpeed;
        }
        else
        {
            float inverse = -1 * (LeftThrust + RightThrust);
            Thrust = ((-1*((float)math.pow(x: inverse, y: Math.Sqrt(3))))*0.001f)*ThrustSpeed;
        }
        /*if ((RightThrust + LeftThrust) > 0)
        {
            Thrust = ThrustSpeed * math.pow((RightThrust + LeftThrust), 0.75f);
        }
        else
        {
            Thrust = -1 * (ThrustSpeed * math.pow(((RightThrust + LeftThrust) * -1), 0.7f));
        }*/

        Ship.transform.position += transform.up * Thrust * Time.deltaTime;
    }
}
