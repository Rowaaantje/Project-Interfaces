using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject A;
    public int Amount;
    void Start()
    {
        for (int i = 0; i < Amount; i++)
        {
            Instantiate(A);
        }
    }
}
