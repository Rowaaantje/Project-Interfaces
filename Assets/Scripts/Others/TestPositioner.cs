using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestPositioner : MonoBehaviour
{
    public GameObject Entity;

    void Start()
    {
        Entity.transform.position = new Vector2(Random.Range(-963f, 963f), Random.Range(-963f, 963f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
