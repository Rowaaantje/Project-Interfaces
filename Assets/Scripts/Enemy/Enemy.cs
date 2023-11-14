using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    public GameObject Entity;
    private GameObject target;
    private Vector2 targetpos;
    public AudioSource AudioSrc;
    public AudioClip a1, a2, a3, a4, a5, a6, a7;
    public bool Agro = false;
    public bool Alive = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Range")
        {
            if (!Agro) { AudioSrc.Play(); }
            Agro = true;
        }
    }
    private void Start()
    {
        AudioClip[] clips = {a1, a2, a3, a4, a5, a6, a7};
        AudioSrc.pitch = Random.Range(0.9f, 1f);
        AudioSrc.clip = clips[Random.Range(0, 6)];
        float num = Random.Range(0.5f, 2f);
        Entity.transform.localScale = new Vector3(num, num, num);
        if (target == null)
            target = GameObject.FindWithTag("Player");
        /*Entity.transform.position = new Vector2(Random.Range(-950f, 950f), Random.Range(-950f, 950f));*/
    }
    void Update()
    {
        if (Alive == true)
        {
            targetpos = target.transform.position;
            transform.right = target.transform.position - transform.position;
            if (Agro == true)
            {
                Entity.transform.position = Vector2.MoveTowards(transform.position, targetpos, 1 * Time.deltaTime);
            }
        }
    }
}
