using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class menuSwitcher : MonoBehaviour
{
    public GameObject Camera;
    public int newPosX;
    public int newPosY;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 newPos = new Vector3(newPosX, newPosY, -150);
        Camera.transform.position = newPos;
        Debug.Log("moved to new pos");
    }
}
