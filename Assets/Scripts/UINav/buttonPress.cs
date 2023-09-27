using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip clickFx;
    
    public void ClickSound()
    {
        myFx.PlayOneShot (clickFx);
    }
}
// {
//     public AudioSource audio;

//     public void playSound()
//     {
//         audio.Play();
//     }
// }
