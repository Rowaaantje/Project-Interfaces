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
    private float _rotationSpeed;
    private float _leftThrust;
    private float _rightThrust;
    private const float RotateThrustSpeed = 0.25f;

    public void game_math()
    {
        _rotationSpeed = _rightThrust + (_leftThrust * -1);
        Ship.rotation += _rotationSpeed * Time.deltaTime;
        if (_leftThrust + _rightThrust > 0)
        {
            Thrust = (((float)math.pow(x: _leftThrust + _rightThrust, y: Math.Sqrt(3))) * 0.0015f) * ThrustSpeed;
        }
        else
        {
            float inverse = -1 * (_leftThrust + _rightThrust);
            Thrust = ((-1 * ((float)math.pow(x: inverse, y: Math.Sqrt(3)))) * 0.001f) * ThrustSpeed;
        }
        Ship.transform.position += transform.up * Thrust * Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetAxis("Left") != 0f || Input.GetAxis("Right") != 0f)
        {
            _leftThrust = Input.GetAxis("Left") * MaxRotation;
            _rightThrust = Input.GetAxis("Right") * MaxRotation;
            game_math();
        }
        else
        {
            if (Input.GetKey("e") && _rightThrust < MaxRotation)
            {
                _rightThrust += RotateThrustSpeed;
            }
            if (Input.GetKey("d") && _rightThrust > -MaxRotation)
            {
                _rightThrust -= RotateThrustSpeed;

            }
            if (Input.GetKey("w") && _leftThrust < MaxRotation)
            {
                _leftThrust += RotateThrustSpeed;
            }
            if (Input.GetKey("s") && _leftThrust > -MaxRotation)
            {
                _leftThrust -= RotateThrustSpeed;
            }
            game_math();
        }
    }
}
