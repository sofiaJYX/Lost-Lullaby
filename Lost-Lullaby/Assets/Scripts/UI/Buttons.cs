using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] Image volumeOnIcon;
    [SerializeField] Image volumeOffIcon;
    private const int NUM_SCENES = 6;

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

    public void TurnMusicOff()
    {
        music.Stop();
        volumeOnIcon.gameObject.SetActive(false);
        volumeOffIcon.gameObject.SetActive(true);
    }

    public void TurnMusicOn()
    {
        music.Play();
        volumeOffIcon.gameObject.SetActive(false);
        volumeOnIcon.gameObject.SetActive(true);
    }
}
