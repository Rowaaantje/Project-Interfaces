using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float gunrange;

    public Transform XYZ_enemy;

    public bool inrange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit attackHit;

        Ray attack = new Ray(transform.position, transform.forward * gunrange);
        Debug.DrawRay(transform.position, transform.forward * gunrange, Color.red);
    }
}
