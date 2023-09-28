using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource Audio;

    public void playClickSound()
    {
        Audio.Play();
    }
}
