using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public AudioSource audio;

    public void playSound()
    {
        audio.Play();
    }
}
