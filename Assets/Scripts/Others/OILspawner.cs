using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OILspawner : MonoBehaviour
{
    public GameObject OIL;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(OIL);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
