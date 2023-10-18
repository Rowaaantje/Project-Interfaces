using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float gunrange;

    public bool inrange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit attackHit;

        Ray attack = new Ray(transform.position, transform.forward * gunrange);
        Debug.DrawRay(transform.position, transform.forward * gunrange, Color.red);

        if (Physics.Raycast(attack, out attackHit, gunrange))
        {
            if (attackHit.collider.gameObject.tag == "Enemy")
            {
                inrange = true;
            }
            else
            {
                inrange = false;
            }
        }

        /*if (inrange)
        {
            transform.LookAt(target.transform);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }*/
    }
}
