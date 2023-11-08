using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public GameObject interactable;
    private CircleCollider2D _collider;
    private bool Entered;
    private void Start()
    {
        _collider = interactable.GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (Entered == true && Input.GetKey(KeyCode.T))
        {
            _collider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Entered = true;
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Entered = false;
        }
    }
}