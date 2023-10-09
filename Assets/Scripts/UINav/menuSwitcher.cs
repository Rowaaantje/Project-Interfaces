using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class menuSwitcher : MonoBehaviour
{
    public GameObject Camera;
    public int newPosX;
    public int newPosY;
    private bool Activated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Activated == false)
        {
            Vector3 newPos = new Vector3(newPosX, newPosY, -730);
            Camera.transform.position = newPos;
            Debug.Log("moved to new pos");
            Activated = true;
        }
        else
        {
            Vector3 newPos = new Vector3(0, 0, -730);
            Camera.transform.position = newPos;
            Debug.Log("moved to new pos");
            Activated = false;
        }
    }
}
