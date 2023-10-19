using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UI;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public Transform gun;
    public float gunRotationSpeed = 100f;

    private GameObject enemytag;
    public bool targetSpotted = false;

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    bool FIRE = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy spotted");
            enemytag = GameObject.FindWithTag("Enemy");
            targetSpotted = true;
        }
        else
        {
            targetSpotted = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Lost");
            RotateToNormal();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void RotateToNormal()
    {
        if(transform.rotation.z > 0)
        {
            transform.Rotate(0, 0, -gunRotationSpeed * Time.deltaTime);
        }
        if(transform.rotation.z < 0)
        {
            transform.Rotate(0, 0, gunRotationSpeed * Time.deltaTime);
        }
    }
    /*void RotateTowardsEnemy()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(enemytag.transform.position - transform.position), gunRotationSpeed * Time.deltaTime);
    }*/

    // Update is called once per frame
    void Update()
    {
        if(targetSpotted)
        {
            transform.right = enemytag.transform.position - transform.position;
            //RotateTowardsEnemy();
        }
        else
        {
            RotateToNormal();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }
}
