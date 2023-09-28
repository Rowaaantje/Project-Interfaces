using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderScript : MonoBehaviour
{
    public GameObject Self;
    void Start()
    {
        Destroy(Self);
    }

}
