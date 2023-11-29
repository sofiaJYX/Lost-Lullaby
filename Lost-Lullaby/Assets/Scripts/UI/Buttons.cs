using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private const int NUM_SCENES = 7;

    public void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == NUM_SCENES)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
