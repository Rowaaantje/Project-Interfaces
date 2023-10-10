using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneScript : MonoBehaviour
{
    public string newSceneTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(newSceneTrigger);
        Debug.Log("clicked");
    }
    public void LoadScene(string scenename)
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
