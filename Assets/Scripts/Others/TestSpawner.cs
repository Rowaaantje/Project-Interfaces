using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject Circle;
    public GameObject Square;
    public int Amount;
    void Start()
    {
        for (int i = 0; i < Amount; i++)
        {
            Instantiate(Circle);
            Instantiate(Square);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
