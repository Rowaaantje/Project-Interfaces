using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Radar : MonoBehaviour
{
    private Transform _sweepTransform;
    private float _radius;
    private List<Collider2D> _colliderList;
    public float sweepSpeed;
    private void Start()
    {
        _sweepTransform = transform.Find("Sweep");
        _radius = 151.74f;
        sweepSpeed = 360;
        _colliderList = new List<Collider2D>();
    }
    private void Update()
    {
        _sweepTransform.eulerAngles -= new Vector3(0, 0, sweepSpeed * Time.deltaTime);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, UtilsClass.GetVectorFromAngle(_sweepTransform.eulerAngles.z), _radius);
        if (raycastHit2D && raycastHit2D.collider.tag == "Enemy")
        {
            if (!_colliderList.Contains(raycastHit2D.collider))
            {
                _colliderList.Add(raycastHit2D.collider);
                Debug.Log("hit");
            }
        }
    }
}
