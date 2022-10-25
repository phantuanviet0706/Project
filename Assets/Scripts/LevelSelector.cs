using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelSelector : MonoBehaviour
{
    public int level;

    private void Start()
    {
        
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Scene Menu");
    }
}
