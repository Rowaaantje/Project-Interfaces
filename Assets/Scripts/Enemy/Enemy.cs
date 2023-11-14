using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    public GameObject Entity;
    private GameObject target;
    private Vector2 targetpos;
    private bool Agro = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Range")
        {
            Agro = true;
            Debug.Log(collision.gameObject.tag);
        }
    }
    private void Start()
    {
        float num = Random.Range(0.1f, 2f);
        Entity.transform.localScale = new Vector3(num, num, num);
        if (target == null)
            target = GameObject.FindWithTag("Player");
        Entity.transform.position = new Vector2(Random.Range(-300f, 300f), Random.Range(-300f, 300f));
    }
    void Update()
    {
        targetpos = target.transform.position;
        transform.right = target.transform.position - transform.position;
        if (Agro)
        {
            Entity.transform.position = Vector2.MoveTowards(transform.position, targetpos, 1 * Time.deltaTime);
        }
    }
}
