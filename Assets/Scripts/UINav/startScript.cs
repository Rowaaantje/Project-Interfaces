using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("SampleScene"); 
        Debug.Log("clicked");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
