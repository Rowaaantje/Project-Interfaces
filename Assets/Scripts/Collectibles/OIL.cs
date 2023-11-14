using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OIL : MonoBehaviour
{
    public Slider OIL_METER1;

    public GameObject OILpatch;
    bool Inrange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Inrange = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        float num = Random.Range(0.1f, 2f);
        OILpatch.transform.localScale = new Vector3(num, num, num);
        OILpatch.transform.position = new Vector2(Random.Range(-500f, 500f), Random.Range(-500f, 500f));
    }

    // Update is called once per frame
    void Update()
    {
        int randomnumber = Random.Range(0, 3);

        if(Inrange == true)
        {
            if (Input.GetButtonDown("Pump_IN"))
            {
                if (randomnumber == 1)
                {
                    OIL_METER1.value += 500;
                }
                else if (randomnumber == 2)
                {
                    OIL_METER1.value += 1000;
                }
                else if (randomnumber == 3)
                {
                    OIL_METER1.value += 1500;
                }
            }
        }
    }
}
