using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private Transform _sweepTransform;
    public float sweepSpeed;
    private void Start()
    {
        _sweepTransform = transform.Find("Sweep");
        sweepSpeed = 360;
    }
    private void Update()
    {
        _sweepTransform.eulerAngles -= new Vector3(0, 0, sweepSpeed * Time.deltaTime);
        Physics2D.Raycast(transform.position, )
    }
}
