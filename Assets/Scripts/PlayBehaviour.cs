using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBehaviour : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AboutMe()
    {
        SceneManager.LoadScene("Scene About Me");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
