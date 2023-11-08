using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public GameObject interactable;
    private CircleCollider2D _collider;
    private void Start()
    {
        _collider = interactable.GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerLayer")
        {
            _collider.enabled = false;
            Debug.Log("");
        }
    }
}
