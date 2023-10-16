using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTest : MonoBehaviour
{
    public Rigidbody2D Ship;
    public float RotationSpeed;
    public float LeftThrust;
    public float RightThrust;
    public float Thrust;
    public int damp = 20;

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKey("e") && RightThrust < 100)
        {
            RightThrust += 1;

        }
        if (Input.GetKey("d") && RightThrust > -100)
        {
            RightThrust -= 1;

        }
        if (Input.GetKey("w") && LeftThrust < 100)
        {
            LeftThrust += 1;
        }
        if (Input.GetKey("s") && LeftThrust > -100)
        {
            LeftThrust -= 1;
        }
        RotationSpeed = RightThrust + (LeftThrust * -1);
        Ship.rotation += RotationSpeed * Time.deltaTime;
        Thrust = (RightThrust + LeftThrust) * 1.5f;
        Ship.transform.position += transform.up * Thrust * Time.deltaTime;
    }
}
