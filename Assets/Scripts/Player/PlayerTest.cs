using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public Rigidbody2D Ship;
    public float MaxRotation, ThrustSpeed, Thrust, WarpCooldown, CooldownTime;
    public int EnergyLevel;
    public GameObject RangeCollider1, RangeCollider2, RangeCollider3;
    private bool _battery1, _battery2, _battery3;
    private float _rotationSpeed;
    private float _leftThrust, _rightThrust;
    private bool _warpActivated = false;
    private const float RotateThrustSpeed = 0.25f;
    private EdgeCollider2D _Player_Collider;

    public void Energy(int energy, GameObject range)
    {
        /*Check if parameter energy is equal to g to turn on the range collider*/
       range.SetActive(EnergyLevel == energy);
    }
    public void BatteryManager(bool batteryStatus)
    {
        EnergyLevel += batteryStatus ? 1 : -1;
    }
    public void CooldownTime_manager(int energy, float time)
    {
        if (EnergyLevel == energy)
        {
            CooldownTime = time;
        }
    }
    public void CooldownCaller()
    {
        CooldownTime_manager(1, 8);
        CooldownTime_manager(2, 6);
        CooldownTime_manager(3, 4);
    }
    public void Player_math()
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
            Player_math();
        }
        else
        {
            /*Testing code for keyboard instead of axises*/
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
            Player_math();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _warpActivated = true;
        }
    } 
    public void Energy_manager()
    {
        /*Activate RangeColliders by using the energy() function*/
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _battery1 = !_battery1;
            BatteryManager(_battery1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _battery2 = !_battery2;
            BatteryManager(_battery2);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _battery3 = !_battery3;
            BatteryManager(_battery3);
        }
        Energy(1, RangeCollider1);
        Energy(2, RangeCollider2);
        Energy(3, RangeCollider3);
        if (_warpActivated)return;
            CooldownCaller();
    }
    public void Timer()
    {
        /*Activate timer that changes _warpActivated to true*/
        if (_warpActivated)
        {
            WarpCooldown -= Time.deltaTime;
        }

        if (!(WarpCooldown < 0))return;
            _warpActivated = false;
            WarpCooldown = CooldownTime;
            CooldownCaller();
            WarpCooldown = CooldownTime;
    }
    public void WarpManager(float duration_1, float duration_2, float duration_3)
    {
        bool enableCollider = false;
        switch (EnergyLevel)
        {
            case 0:
                enableCollider = true;
                break;
            case 1:
                if (WarpCooldown == CooldownTime || WarpCooldown == 0 || WarpCooldown < (CooldownTime - duration_1))
                {
                    enableCollider = true;
                }
                if (enableCollider == false)
                {
                    _leftThrust = 0;
                    _rightThrust = 0;
                }
                break;
            case 2:
                if (WarpCooldown == CooldownTime || WarpCooldown == 0 || WarpCooldown < (CooldownTime - duration_2))
                {
                    enableCollider = true;
                }
                break;
            case 3:
                if (WarpCooldown == CooldownTime || WarpCooldown == 0 || WarpCooldown < (CooldownTime - duration_3))
                {
                    enableCollider = true;
                }

                if (enableCollider == false)
                {
                    ThrustSpeed = 1.5f;
                }
                else
                {
                    ThrustSpeed = 1;
                }
                break;
        }
        _Player_Collider.enabled = enableCollider;
    }
    void Start()
    {
       _Player_Collider = Ship.GetComponent<EdgeCollider2D>();
    }
    void Update()
    {
       Controller();
       Energy_manager();
       Timer();
       WarpManager(1f,1.5f,2f);
    }
}