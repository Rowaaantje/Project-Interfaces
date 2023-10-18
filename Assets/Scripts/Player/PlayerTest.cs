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
        RightThrust = Input.GetAxis("RightHandle") * 90;
        LeftThrust = Input.GetAxis("LeftHandle") * 90;
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
        if ((RightThrust + LeftThrust) > 0)
        {
            Thrust = 10 * math.pow((RightThrust + LeftThrust), 0.75f);
        }
        else
        {
            Thrust = -1*(10 * math.pow(((RightThrust + LeftThrust)*-1), 0.7f));
        }
        
        Ship.transform.position += transform.up * Thrust * Time.deltaTime;
    }
}
