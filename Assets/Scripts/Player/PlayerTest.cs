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
    public int EnergyLevel = 1;
    public GameObject RangeCollider1;
    public GameObject RangeCollider2;
    public GameObject RangeCollider3;
    private float _rotationSpeed;
    private float _leftThrust;
    private float _rightThrust;
    private const float RotateThrustSpeed = 0.25f;

    public void Energy(int energy, GameObject range)
    {
        /*Check if parameter energy is equal to EnergyLevel to turn on the range collider*/
       range.SetActive(EnergyLevel == energy);
    }
    public void Game_math()
    {
        /*Rotate with the combined speed of _rightThrust and _leftThrust*/
        _rotationSpeed = _rightThrust + (_leftThrust * -1);
        Ship.rotation += _rotationSpeed * Time.deltaTime;
        /*If _leftThrust + _rightThrust are more then 0 use formula ((_leftThrust + RightThrust)^1/3)*0.0015 to gain an exponent thrust.
         If _leftThrust + _rightThrust are less then 0 inverse the formula to gain backwards thrust at a slower rate*/
        if (_leftThrust + _rightThrust > 0)
        {
            Thrust = (((float)math.pow(x: _leftThrust + _rightThrust, y: Math.Sqrt(3))) * 0.0015f) * ThrustSpeed;
        }
        else
        { 
            /*Inverse the formula*/
            var inverse = -1 * (_leftThrust + _rightThrust);
            Thrust = ((-1 * ((float)math.pow(x: inverse, y: Math.Sqrt(3)))) * 0.001f) * ThrustSpeed;
        }
        Ship.transform.position += Thrust * Time.deltaTime * transform.up;
    }
    public void Controller()
    {
        /*Check if controller or keyboard is used (for testing) to only allow the Game_math() function to run with right inputs*/
        if (Input.GetAxis("Left") != 0f || Input.GetAxis("Right") != 0f)
        {
            _leftThrust = Input.GetAxis("Left") * MaxRotation;
            _rightThrust = Input.GetAxis("Right") * MaxRotation;
            Game_math();
        }
        else
        {
            if (Input.GetKey(KeyCode.E) && _rightThrust < MaxRotation)
            {
                _rightThrust += RotateThrustSpeed;
            }
            if (Input.GetKey(KeyCode.D) && _rightThrust > -MaxRotation)
            {
                _rightThrust -= RotateThrustSpeed;
            }
            if (Input.GetKey(KeyCode.W) && _leftThrust < MaxRotation)
            {
                _leftThrust += RotateThrustSpeed;
            }
            if (Input.GetKey(KeyCode.S) && _leftThrust > -MaxRotation)
            {
                _leftThrust -= RotateThrustSpeed;
            }
            Game_math();
        }
    }

    public void Energy_manager()
    {
        /*Activate RangeColliders by using the Energy() function*/
        if (Input.GetKeyDown(KeyCode.UpArrow) && EnergyLevel < 3)
        {
            EnergyLevel += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && EnergyLevel > 1)
        {
            EnergyLevel -= 1;
        }
        Energy(1, RangeCollider1);
        Energy(2, RangeCollider2);
        Energy(3, RangeCollider3);
    }

    void Update()
    {
       Controller();
       Energy_manager();
    }
}
