using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipIntro : MonoBehaviour
{
    public string scenename;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(scenename);
            Debug.Log("clicked");
        }
    }
}
