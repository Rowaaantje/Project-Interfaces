using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneScript : MonoBehaviour
{
    public void loadScene(string scenename)
    {
        SceneManager.LoadScene(scenename); 
        Debug.Log("clicked");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
