using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ShipClass : MonoBehaviour
{
    public int Fuel;
    public void TakeFuel(int OtherFuel)
    {
        Fuel += OtherFuel;
    }
    public int GiveFuel()
    {
        int FuelGiven = Fuel;
        Fuel = 0;
        return FuelGiven;
    }
}